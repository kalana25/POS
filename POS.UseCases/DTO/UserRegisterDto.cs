using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
