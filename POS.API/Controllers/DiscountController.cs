using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using POS.Core.General;
using POS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using POS.UseCases.DTO;
using POS.UseCases.General.Discounts.GetDiscounts;
using POS.UseCases.General.Discounts.GetDiscount;
using POS.UseCases.General.Discounts.PaginatedDiscounts;
using POS.UseCases.General.Discounts.SaveDiscount;
using POS.UseCases.General.Discounts.UpdateDiscount;
using POS.UseCases.General.Discounts.DeleteDiscount;

namespace POS.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IUseCaseFactory usecaseFactory;
        public DiscountController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination([FromQuery]RequestData req)
        {
            try
            {
                var discountPagination = usecaseFactory.Create<PaginatedDiscountsUsecase>();
                discountPagination.RequestData = req;
                var result = await discountPagination.Execute();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody] DiscountSaveDto discount)
        {
            try
            {
                if (discount == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var saveDiscount = usecaseFactory.Create<SaveDiscountUsecase>();
                    saveDiscount.Dto = discount;
                    var result = await saveDiscount.Execute();

                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("findall/")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var findDiscounts = usecaseFactory.Create<GetDiscountsUsecase>();
                var result = await findDiscounts.Execute();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("find/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }

                var findDiscount = usecaseFactory.Create<GetDiscountUsecase>();
                findDiscount.Id = id;
                var result = await findDiscount.Execute();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DiscountSaveDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var updateDiscount = usecaseFactory.Create<UpdateDiscountUsecase>();
                    updateDiscount.Dto = dto;
                    updateDiscount.Id = id;
                    var result = await updateDiscount.Execute();
                    return CreatedAtAction(nameof(Get), new { id = result }, result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return NotFound();
                }
                var deleteDiscount = usecaseFactory.Create<DeleteDiscountUsecase>();
                deleteDiscount.Id = id;
                var result = await deleteDiscount.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}