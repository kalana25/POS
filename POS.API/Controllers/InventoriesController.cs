﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using POS.UseCases.General.Inventories.PaginatedInventories;
using POS.UseCases.General.Inventories.GetInventoryByItem;
using POS.Core.Interfaces;
using POS.Core.General;

namespace POS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {

        private readonly IUseCaseFactory usecaseFactory;

        public InventoriesController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination([FromQuery]RequestData req)
        {
            try
            {
                var inventoryPagination = usecaseFactory.Create<PaginatedInventoriesUsecase>();
                inventoryPagination.RequestData = req;
                var result = await inventoryPagination.Execute();
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

        [HttpGet("fullinfo/find/ItemId/{itemId}")]
        public async Task<IActionResult> GetFullInfo(int itemId)
        {
            try
            {
                if (itemId < 1)
                {
                    return BadRequest();
                }

                var findInventoryFullInfo = usecaseFactory.Create<GetInventoryByItemUsecase>();
                findInventoryFullInfo.ItemId = itemId;
                var result = await findInventoryFullInfo.Execute();
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