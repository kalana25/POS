using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaWeb.Core.General
{
    public class AppSettings
    {
        public ConnectionString ConnectionString { get; set; }
    }

    public class ConnectionString
    {
        public string Development { get; set; }
        public string Production { get; set; }
        public string QA { get; set; }
    }
}
