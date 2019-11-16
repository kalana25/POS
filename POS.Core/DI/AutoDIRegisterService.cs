using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AgendaWeb.Core.DI
{
    public class AutoDIRegisterService
    {
        private readonly Dictionary<string, AutoDIServiceInfo> map;
        private readonly IServiceCollection services;

        public AutoDIRegisterService(IServiceCollection services)
        {
            this.services = services;
            this.map = this.GetDependencyInjectionMap();
        }

        public void RegisterAssemblies(string fileName = "appsettings.json")
        {
            var jsonAssemblies = JObject.Parse(File.ReadAllText(fileName))["AutoDIRegisterService"]["assemblies"];
            if (jsonAssemblies != null)
            {
                var requiredAssemblies = JsonConvert.DeserializeObject<List<AutoDIAssemblieInfo>>(jsonAssemblies.ToString());
                foreach (var requiredAssembly in requiredAssemblies)
                {
                    if (requiredAssembly != null && !string.IsNullOrEmpty(requiredAssembly.Name))
                    {
                        try
                        {
                            this.RegisterFromAssembly(requiredAssembly.Name);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error trying to register '{requiredAssembly.Name}' assembly.", ex);
                        }
                    }
                }
            }
        }

        public List<AutoDIServiceInfo> GetAssemblyInjetedDependencies(Assembly assembly)
        {
            List<AutoDIServiceInfo> resut = new List<AutoDIServiceInfo>();

            var interfaces = assembly.GetExportedTypes().Where(e => e.IsInterface)
                .Where(e => e.CustomAttributes.Any(c => c.AttributeType == typeof(AutoDIServiceAttribute)));
            if (interfaces != null)
            {
                foreach (var interficie in interfaces)
                {
                    var service = this.GetServiceInfoFromMap(interficie);
                    if (service == null)
                    {
                        var interfaceTypeName = interficie.FullName;
                        var implementationTypeName = this.GetImplementationTypeFromParameters(interficie);
                        if (string.IsNullOrEmpty(implementationTypeName))
                        {
                            implementationTypeName = this.GetDefaultImplementationType(interficie);
                        }

                        var lifetimeType = ServiceLifetime.Transient;

                        var lifetime = this.GetLifetimeFromParameters(interficie);
                        if (lifetime != null)
                        {
                            lifetimeType = (ServiceLifetime)lifetime;
                        }

                        service = new AutoDIServiceInfo(
                            service: interfaceTypeName,
                            implementation: implementationTypeName,
                            lifetime: lifetimeType);
                        service.ServiceAssembly = assembly;
                    }

                    resut.Add(service);
                }
            }

            return resut;
        }

        public Type GetType(string typename)
        {
            Type result = null;
            if (typename.Contains("."))
            {
                Assembly assembly = null;
                var assemblyNamespace = typename.Split('.');
                int maxNumNamespaces = assemblyNamespace.Length - 1;
                while (maxNumNamespaces > 0)
                {
                    var namespaceName = string.Empty;
                    for (int n = 0; n < maxNumNamespaces; n++)
                    {
                        if (namespaceName != string.Empty)
                        {
                            namespaceName += ".";
                        }

                        namespaceName += assemblyNamespace[n];
                    }

                    try
                    {
                        assembly = System.Reflection.Assembly.Load(namespaceName);
                        break;
                    }
                    catch
                    {
                    }

                    maxNumNamespaces--;
                }

                if (assembly == null)
                {
                    throw new Exception($"Assembly: '{typename}' not found.");
                }
                else
                {
                    result = assembly.GetType(typename);
                }
            }
            else
            {
                result = Type.GetType(typename);
            }

            if (result == null)
            {
                throw new Exception($"Type: '{typename}' not found.");
            }

            return result;
        }

        private void RegisterFromAssembly(string assemblyName, string path = "")
        {
            assemblyName = assemblyName.Trim();
            var assemblyFileName = assemblyName;
            if (!assemblyName.ToUpper().EndsWith(".DLL"))
            {
                assemblyFileName += ".dll";
            }

            if (string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory;
            }

            string assemblyFile = Path.Combine(path, assemblyFileName);
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom(assemblyFile);

                if (!this.IsAssemblyLoaded(assemblyName))
                {
                    Microsoft.Extensions.DependencyModel.DependencyContextLoader.Default.Load(assembly);
                }
            }
            catch (FileNotFoundException fnotfoundEx)
            {
                throw fnotfoundEx;
            }

            if (assemblyName.ToUpper().EndsWith(".DLL"))
            {
                assemblyName = assemblyName.Substring(0, assemblyName.Length - 4);
            }

            var injectionData = this.GetAssemblyInjetedDependencies(assembly);
            foreach (var injection in injectionData)
            {
                try
                {
                    var interfaceType = this.GetType(injection.Service);
                    var inplementationType = this.GetType(injection.Implementation);

                    if (interfaceType != null && inplementationType != null && inplementationType.GetInterfaces().Any(c => c == interfaceType))
                    {
                        var lifetime = injection.Lifetime;
                        this.services.Add(
                            new ServiceDescriptor(
                                serviceType: interfaceType,
                                implementationType: inplementationType,
                                lifetime: lifetime));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error trying to register injection service: '{injection.Service} with implementation: '{injection.Implementation}'. Exception: {ex.Message}");
                }
            }
        }

        private AutoDIServiceInfo GetServiceInfoFromMap(Type interficie)
        {
            AutoDIServiceInfo result = null;
            if (interficie != null)
            {
                var interfaceTypeName = interficie.FullName;
                if (this.map != null && this.map.ContainsKey(interfaceTypeName))
                {
                    result = this.map[interfaceTypeName];
                }
            }

            return result;
        }

        private string GetImplementationTypeFromParameters(Type interficie)
        {
            var implementationTypeName = string.Empty;
            var customAttr = interficie.CustomAttributes.SingleOrDefault(c => c.AttributeType == typeof(AutoDIServiceAttribute));
            if (customAttr == null)
            {
                throw new Exception($"Interface '{interficie.FullName}' doesn't has a 'ServiceImplementationAttribute' CustomAttibute.");
            }

            var implementationArgument = customAttr.ConstructorArguments[0].Value as string;

            if (!string.IsNullOrEmpty(implementationArgument))
            {
                var interfaceTypeName = interficie.FullName;
                var interfaceName = interficie.FullName.Split(".").Last();
                var interfaceAssemblyName = interficie.FullName.Substring(0, interficie.FullName.Length - (interfaceName.Length + 1));

                if (implementationArgument.Contains('.'))
                {
                    implementationTypeName = implementationArgument;
                }
                else
                {
                    implementationTypeName = interfaceAssemblyName + "." + implementationArgument;
                }
            }

            return implementationTypeName;
        }

        private string GetDefaultImplementationType(Type interficie)
        {
            var implementationTypeName = string.Empty;

            var interfaceTypeName = interficie.FullName;
            var name = interficie.FullName.Split(".").Last();
            var interfaceAssemblyName = interficie.FullName.Substring(0, interficie.FullName.Length - (name.Length + 1));
            implementationTypeName = interfaceAssemblyName + "." + name.Substring(1);

            return implementationTypeName;
        }

        private int? GetLifetimeFromParameters(Type interficie)
        {
            var customAttr = interficie.CustomAttributes.SingleOrDefault(c => c.AttributeType == typeof(AutoDIServiceAttribute));
            if (customAttr == null)
            {
                throw new Exception($"Interface '{interficie.FullName}' doesn't has a 'ServiceImplementationAttribute' CustomAttibute.");
            }

            if (customAttr.ConstructorArguments.Count > 1)
            {
                return (int)customAttr.ConstructorArguments[1].Value;
            }
            else
            {
                return null;
            }
        }

        private Dictionary<string, AutoDIServiceInfo> GetDependencyInjectionMap(string fileName = "appsettings.json")
        {
            Dictionary<string, AutoDIServiceInfo> map = new Dictionary<string, AutoDIServiceInfo>();

            var jsonServices = JObject.Parse(File.ReadAllText(fileName))["AutoDIRegisterService"]["services"];
            if (jsonServices != null)
            {
                var requiredServices = JsonConvert.DeserializeObject<List<AutoDIServiceInfo>>(jsonServices.ToString());

                foreach (var service in requiredServices)
                {
                    if (map.ContainsKey(service.Service))
                    {
                        map[service.Service] = service;
                    }
                    else
                    {
                        map.Add(service.Service, service);
                    }
                }
            }

            return map;
        }

        private bool IsAssemblyLoaded(string assemblyName)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(t => t.FullName.StartsWith(assemblyName))
                .FirstOrDefault() == null ? false : true;
        }
    }
}
