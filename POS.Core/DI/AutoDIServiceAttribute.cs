using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaWeb.Core.DI
{
    public class AutoDIServiceAttribute : Attribute
    {
        private readonly string implementationType;
        private readonly ServiceLifetime lifetime = ServiceLifetime.Transient;

        public AutoDIServiceAttribute(string implementationType = "", ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            this.implementationType = implementationType;
            this.lifetime = lifetime;
        }

        public virtual string ImplementationType
        {
            get { return this.implementationType; }
        }

        public virtual ServiceLifetime Lifetime
        {
            get { return this.lifetime; }
        }
    }
}
