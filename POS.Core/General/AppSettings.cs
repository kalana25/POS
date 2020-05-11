using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Core.General
{
    public class AppSettings
    {
        public ConnectionString ConnectionString { get; set; }
        public Auth Auth { get; set; }
    }

    public class ConnectionString
    {
        public string Development { get; set; }
        public string Production { get; set; }
        public string QA { get; set; }
    }

    public class Auth
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }

    }
}
