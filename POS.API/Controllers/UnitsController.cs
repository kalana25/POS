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
using POS.UseCases.General.PurchaseUnits.PaginatedPurchaseUnits;
using POS.UseCases.General.PurchaseUnits.GetPurchaseUnit;
using POS.UseCases.General.PurchaseUnits.GetPurchaseUnits;
using POS.UseCases.General.PurchaseUnits.DeletePurchaseUnit;
using POS.UseCases.General.PurchaseUnits.SavePurchaseUnit;
using POS.UseCases.General.PurchaseUnits.UpdatePurchaseUnit;
using POS.UseCases.General.PurchaseUnits.GetPurchaseUnitsByItem;
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

        #region Base Unit

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

        #endregion

        #region Purchase Unit

        [HttpGet("purchase/pagination")]
        public async Task<IActionResult> GetPunitPagination([FromQuery]RequestData req)
        {
            try
            {
                var purchaseUnitPagination = usecaseFactory.Create<PaginatedPurchaseUnitsUsecase>();
                purchaseUnitPagination.RequestData = req;
                var result = await purchaseUnitPagination.Execute();
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

        [HttpPost("purchase/save")]
        public async Task<IActionResult> PostPunit([FromBody] PurchaseUnitSaveDto unit)
        {
            try
            {
                if (unit == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var savePurchaseUnit = usecaseFactory.Create<SavePurchaseUnitUsecase>();
                    savePurchaseUnit.Dto = unit;
                    savePurchaseUnit.CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var result = await savePurchaseUnit.Execute();

                    return CreatedAtAction(nameof(GetPunit), new { id = result.Id }, result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("purchase/update/{id}")]
        public async Task<IActionResult> PutPunit(int id, [FromBody] PurchaseUnitSaveDto unit)
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
                    var updatePurchaseUnit = this.usecaseFactory.Create<UpdatePurchaseUnitUsecase>();
                    updatePurchaseUnit.Id = id;
                    updatePurchaseUnit.Dto = unit;
                    updatePurchaseUnit.UpdatedBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var result = await updatePurchaseUnit.Execute();
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("purchase/delete/{id}")]
        public async Task<IActionResult> DeletePunit(int id)
        {
            try
            {
                if (id < 1)
                {
                    return NotFound();
                }
                var deletePurchaseUnit = usecaseFactory.Create<DeletePurchaseUnitUsecase>();
                deletePurchaseUnit.Id = id;
                var result = await deletePurchaseUnit.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("purchase/findall/")]
        public async Task<IActionResult> GetAllPunit()
        {
            try
            {
                var findPurchaseUnits = usecaseFactory.Create<GetPurchaseUnitsUsecase>();
                var result = await findPurchaseUnits.Execute();
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

        [HttpGet("purchase/find/{id}")]
        public async Task<IActionResult> GetPunit(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }

                var findPurchaseUnit = usecaseFactory.Create<GetPurchaseUnitUsecase>();
                findPurchaseUnit.Id = id;
                var result = await findPurchaseUnit.Execute();
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

        [HttpGet("purchase/find/item/{id}")]
        public async Task<IActionResult> GetPunitByItem(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }

                var findPurchaseUnitsByItem = usecaseFactory.Create<GetPurchaseUnitsByItemUsecase>();
                findPurchaseUnitsByItem.ItemId = id;
                var result = await findPurchaseUnitsByItem.Execute();
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

        #endregion
    }
}