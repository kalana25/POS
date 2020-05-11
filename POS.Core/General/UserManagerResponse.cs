using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Core.General
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime? Expire { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
