using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Core.General
{
    public class ExtendedRequestData:IRequestData
    {
        public ExtendedRequestData()
        {
            Page = 1;
            PageSize = 10;
        }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string Columns { get; set; }

        public string Filter { get; set; }

        public string OrderBy { get; set; }
    }
}
