using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Core.General
{
    public class RequestData
    {
        public RequestData()
        {
            Page = 1;
            PageSize = 10;
        }
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string Columns { get; set; }

        public string Filter { get; set; }

        public string OrderBy { get; set; }
    }
}
