using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.UseCases.DTO;
using POS.Core.General;
using POS.Core.Interfaces;
using POS.UseCases.General.Suppliers.PaginatedSuppliers;
using POS.UseCases.General.Suppliers.SaveSupplier;
using POS.UseCases.General.Suppliers.GetSuppliers;
using POS.UseCases.General.Suppliers.GetSupplier;
using POS.UseCases.General.Suppliers.UpdateSupplier;
using POS.UseCases.General.Suppliers.DeleteSupplier;

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

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination([FromQuery]RequestData req)
        {
            try
            {
                var supplierPagination = usecaseFactory.Create<PaginatedSuppliersUsecase>();
                supplierPagination.RequestData = req;
                var result = await supplierPagination.Execute();
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

        [HttpGet("findall/")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var findSuppliers = usecaseFactory.Create<GetSuppliersUsecase>();
                var result = await findSuppliers.Execute();
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SupplierSaveDto supplier)
        {
            try
            {
                if (id < 0)
                {
                    return NotFound();
                }
                if (supplier == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var updateSupplier = this.usecaseFactory.Create<UpdateSupplierUseCase>();
                    updateSupplier.Id = id;
                    updateSupplier.Dto = supplier;
                    var result = await updateSupplier.Execute();
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return NotFound();
                }
                var deleteSupplier = usecaseFactory.Create<DeleteSupplierUsecase>();
                deleteSupplier.Id = id;
                var result = await deleteSupplier.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
