using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using POS.UseCases.DTO;
using POS.Core.Interfaces;
using POS.UseCases.General.Orders.GetNextSalesCode;
using POS.Core.General;

namespace POS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUseCaseFactory usecaseFactory;

        public OrderController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("find/next/code")]
        public async Task<IActionResult> GetNextOrderCode()
        {
            try
            {
                var nextItemCode = usecaseFactory.Create<GetNextOrderCodeUsecase>();
                var result = await nextItemCode.Execute();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(new { code = result });
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
