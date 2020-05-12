using System.Threading.Tasks;
using POS.Core.Interfaces;
using POS.Core.General;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace POS.UseCases.General.Authentication.LoginUser
{
    public class LoginUserUsecase:UseCase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;

        public UserLoginDto Dto { get; set; }

        public LoginUserUsecase(
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<UserManagerResponse> Execute()
        {
            var user = await userManager.FindByEmailAsync(Dto.Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "There is no such user with that email address"
                };
            
            var result = await userManager.CheckPasswordAsync(user, Dto.Password);
            if (!result)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Incorrect password"
                };

            var claims = new[]
            {
                new Claim("Email",Dto.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
            };

            var appSettings = configuration.Get<AppSettings>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Auth.Secret));

            var token = new JwtSecurityToken(
                issuer:appSettings.Auth.Issuer,
                audience:appSettings.Auth.Audience,
                claims:claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = tokenString,
                Expire = token.ValidTo
            };
        }
    }
}
