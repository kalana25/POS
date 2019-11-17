using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.UseCases.DTO;
using POS.Core.Interfaces;
using POS.UseCases.General.Suppliers.SaveSupplier;
using POS.UseCases.General.Suppliers.GetSupplier;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IUseCaseFactory usecaseFactory;

        public SuppliersController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupplierSaveDto supplier)
        {
            try
            {
                if (supplier == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var saveSupplier = usecaseFactory.Create<SaveSupplierUsecase>();
                    saveSupplier.Dto = supplier;
                    var result = await saveSupplier.Execute();
                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
                }
                return BadRequest();
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

                var findSupplier = usecaseFactory.Create<GetSupplierUsecase>();
                findSupplier.Id = id;
                var result = await findSupplier.Execute();
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


    }
}
