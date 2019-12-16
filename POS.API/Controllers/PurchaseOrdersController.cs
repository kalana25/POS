using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.UseCases.DTO;
using POS.Core.Interfaces;
using POS.Core.General;
using POS.UseCases.General.PurchaseOrders.GetPurchaseOrders;
using POS.UseCases.General.Items.GetItem;
using POS.UseCases.General.Items.PaginatedItems;
using POS.UseCases.General.Items.SaveItem;
using POS.UseCases.General.Items.UpdateItem;
using POS.UseCases.General.Items.DeleteItem;

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

    }
}
