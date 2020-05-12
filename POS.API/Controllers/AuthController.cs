using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Core.Interfaces;
using POS.Core.General;
using POS.UseCases.DTO;
using POS.UseCases.General.Authentication.RegisterUser;
using POS.UseCases.General.Authentication.LoginUser;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUseCaseFactory usecaseFactory;

        public AuthController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                if(ModelState.IsValid)
                {
                    var registerUser = usecaseFactory.Create<RegisterUserUsecase>();
                    registerUser.Dto = model;
                    var result = await registerUser.Execute();
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginDto model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                if(ModelState.IsValid)
                {
                    var loginUser = usecaseFactory.Create<LoginUserUsecase>();
                    loginUser.Dto = model;
                    var result = await loginUser.Execute();
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}