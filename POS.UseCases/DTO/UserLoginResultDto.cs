using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class UserLoginResultDto
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime? Expire { get; set; }
        public UserInfoDto LoggedUser { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
