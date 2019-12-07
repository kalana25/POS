using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Core.General
{
    public class ResponseData<T>
    {
        public ResponseData(int page)
        {
            Page = page;
        }

        public ResponseData(int page,int pageSize,int totalCount,IEnumerable<T>items)
        {
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            Items = items;
            PageCount = (int)Math.Ceiling((double)totalCount / pageSize);
        }
        public int Page { get; }

        public int PageSize { get; }

        public int PageCount { get; }

        public int TotalCount { get; }

        public IEnumerable<T> Items { get; }
    }
}
