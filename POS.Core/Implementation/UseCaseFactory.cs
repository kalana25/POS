using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Core.Interfaces;

namespace AgendaWeb.Core.Implementation
{
    public class UseCaseFactory : IUseCaseFactory
    {
        private readonly IServiceProvider serviceProvider;

        public UseCaseFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T Create<T>() where T : UseCase
        {
            Type type = typeof(T);
            var ctors = type.GetConstructors()[0];
            var parameters = new List<object>();

            foreach (var property in ctors.GetParameters())
            {
                var parameterType = property.ParameterType;
                parameters.Add(this.serviceProvider.GetService(parameterType));
            }

            T instance = ctors.Invoke(parameters.ToArray()) as T;
            return instance;
        }
    }
}
