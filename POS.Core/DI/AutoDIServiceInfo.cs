using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaWeb.Core.DI
{
    public class AutoDIServiceInfo
    {
        public AutoDIServiceInfo()
        {
        }

        public AutoDIServiceInfo(string service, string implementation, ServiceLifetime lifetime)
        {
            this.Service = service;
            this.Implementation = implementation;
            this.Lifetime = lifetime;
        }

        public Assembly ServiceAssembly { get; set; }

        public Assembly ImplementationAssembly { get; set; }

        public string Service { get; set; }

        public string Implementation { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceLifetime Lifetime { get; set; }
    }
}
