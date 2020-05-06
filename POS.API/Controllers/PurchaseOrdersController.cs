using Microsoft.AspNetCore.Mvc;
using POS.Core.General;
using POS.Core.Interfaces;
using POS.UseCases.DTO;
using POS.UseCases.General.PurchaseOrders.DeletePurchaseOrder;
using POS.UseCases.General.PurchaseOrders.GetPurchaseOrder;
using POS.UseCases.General.PurchaseOrders.GetPurchaseOrderFullInfo;
using POS.UseCases.General.PurchaseOrders.GetPurchaseOrders;
using POS.UseCases.General.PurchaseOrders.PaginatedPurchaseOrders;
using POS.UseCases.General.PurchaseOrders.SavePurchaseOrder;
using POS.UseCases.General.PurchaseOrders.UpdatePurchaseOrder;
using System;
using System.Threading.Tasks;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IUseCaseFactory usecaseFactory;

        public PurchaseOrdersController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination([FromQuery]RequestData req)
        {
            try
            {
                var itemPagination = usecaseFactory.Create<PaginatedPurchaseOrdersUsecase>();
                itemPagination.RequestData = req;
                var result = await itemPagination.Execute();
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

        [HttpGet("header/findall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var findPurchaseOrders = usecaseFactory.Create<GetPurchaseOrdersUsecase>();
                var result = await findPurchaseOrders.Execute();
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

        [HttpGet("header/find/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }

                var findPurchaseOrder = usecaseFactory.Create<GetPurchaseOrderUsecase>();
                findPurchaseOrder.Id = id;
                var result = await findPurchaseOrder.Execute();
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

        [HttpGet("fullinfo/find/{id}")]
        public async Task<IActionResult> GetFullInfo(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }

                var findPoFullInfo = usecaseFactory.Create<GetPurchaseOrderFullInfoUsecase>();
                findPoFullInfo.Id = id;
                var result = await findPoFullInfo.Execute();
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
        public async Task<IActionResult> Post([FromBody] PurchaseOrderSaveDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var savePo = usecaseFactory.Create<SavePurchaseOrderUsecase>();
                    savePo.Dto = dto;
                    var result = await savePo.Execute();
                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put(int Id,[FromBody] PurchaseOrderUpdateDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var updatePo = usecaseFactory.Create<UpdatePurchaseOrderUsecase>();
                    updatePo.Dto = dto;
                    updatePo.Id = Id;
                    var result = await updatePo.Execute();
                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
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
                var deletePurchaseOrder = usecaseFactory.Create<DeletePurchaseOrderDeleteUsecase>();
                deletePurchaseOrder.Id = id;
                var result = await deletePurchaseOrder.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
