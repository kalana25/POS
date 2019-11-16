using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaWeb.Core.DI
{
    public class AutoDIAssemblieInfo
    {
        public AutoDIAssemblieInfo()
        {
        }

        public AutoDIAssemblieInfo(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
