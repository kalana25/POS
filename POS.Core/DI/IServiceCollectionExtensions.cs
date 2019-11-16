using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.General;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaWeb.Core.DI
{
    public static class IServiceCollectionExtensions
    {
        public static IConfiguration Configuration { get; set; }

        public static AppSettings AddServiceCore(this IServiceCollection services, IConfiguration configuration)
        {
            // App configuration service
            var configApp = configuration.Get<AppSettings>();            // Load Config
            services.AddSingleton<AppSettings>(cfg => configApp); // Register Config Singleton
            return configApp;
        }

        public static IServiceCollection AutoDIRegisterService(this IServiceCollection services, Action<object> options = null)
        {
            var register = new AutoDIRegisterService(services);
            register.RegisterAssemblies();
            return services;
        }
    }
}
