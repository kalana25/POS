using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using POS.Core.General;
using POS.Core.Interfaces;
using POS.UseCases.General.BaseUnits.PaginatedBaseUnits;
using POS.UseCases.General.BaseUnits.GetBaseUnits;
using POS.UseCases.General.BaseUnits.GetBaseUnit;
using POS.UseCases.General.BaseUnits.DeleteBaseUnit;
using POS.UseCases.General.BaseUnits.SaveBaseUnit;
using POS.UseCases.General.BaseUnits.UpdateBaseUnit;
using POS.UseCases.DTO;
using System.Security.Claims;

namespace POS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUseCaseFactory usecaseFactory;

        public UnitsController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("base/pagination")]
        public async Task<IActionResult> GetPagination([FromQuery]RequestData req)
        {
            try
            {
                var baseUnitPagination = usecaseFactory.Create<PaginatedBaseUnitsUsecase>();
                baseUnitPagination.RequestData = req;
                var result = await baseUnitPagination.Execute();
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

        [HttpPost("base/save")]
        public async Task<IActionResult> Post([FromBody] BaseUnitSaveDto unit)
        {
            try
            {
                if (unit == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var saveBaseUnit = usecaseFactory.Create<SaveBaseUnitUsecase>();
                    saveBaseUnit.Dto = unit;
                    saveBaseUnit.CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var result = await saveBaseUnit.Execute();

                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("base/update/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BaseUnitSaveDto unit)
        {
            try
            {
                if (id < 0)
                {
                    return NotFound();
                }
                if (unit == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var updateBaseUnit = this.usecaseFactory.Create<UpdateBaseUnitUsecase>();
                    updateBaseUnit.Id = id;
                    updateBaseUnit.Dto = unit;
                    updateBaseUnit.UpdatedBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var result = await updateBaseUnit.Execute();
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("base/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return NotFound();
                }
                var deleteBaseUnit = usecaseFactory.Create<DeleteBaseUnitUsecase>();
                deleteBaseUnit.Id = id;
                var result = await deleteBaseUnit.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("base/findall/")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var findBaseUnits = usecaseFactory.Create<GetBaseUnitsUsecase>();
                var result = await findBaseUnits.Execute();
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

        [HttpGet("base/find/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }

                var findBaseUnit = usecaseFactory.Create<GetBaseUnitUsecase>();
                findBaseUnit.Id = id;
                var result = await findBaseUnit.Execute();
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