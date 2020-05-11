using System.Threading.Tasks;
using POS.Core.Interfaces;
using POS.Core.General;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace POS.UseCases.General.Authentication.RegisterUser
{
    public class RegisterUserUsecase:UseCase
    {
        public UserRegisterDto Dto { get; set; }

        private readonly UserManager<IdentityUser> userManager;

        public RegisterUserUsecase(
            UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<UserManagerResponse> Execute()
        {
            if(Dto.Password !=Dto.ConfirmPassword)
            {
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Confirm password doesn't matched with password"
                };
            }

            var identityUser = new IdentityUser
            {
                Email = Dto.Email,
                UserName = Dto.Email
            };

            var result = await userManager.CreateAsync(identityUser, Dto.Password);
            if(result.Succeeded)
            {
                return new UserManagerResponse
                {
                    IsSuccess = true,
                    Message = "User created successfully"
                };
            }

            return new UserManagerResponse
            {
                IsSuccess = false,
                Message = "User is not created",
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
}
