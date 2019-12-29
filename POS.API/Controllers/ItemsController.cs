using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.UseCases.DTO;
using POS.Core.Interfaces;
using POS.Core.General;
using POS.UseCases.General.Items.GetItems;
using POS.UseCases.General.Items.GetItemsByLevel;
using POS.UseCases.General.Items.GetItem;
using POS.UseCases.General.Items.PaginatedItems;
using POS.UseCases.General.Items.SaveItem;
using POS.UseCases.General.Items.UpdateItem;
using POS.UseCases.General.Items.DeleteItem;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUseCaseFactory usecaseFactory;

        public ItemsController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("findall/")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var findItems = usecaseFactory.Create<GetItemsUsecase>();
                var result = await findItems.Execute();
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

        [HttpGet("findall/level/{level}")]
        public async Task<IActionResult> GetAllByLevel(int level)
        {
            try
            {
                var findCategorisByLevel = usecaseFactory.Create<GetItemsByLevelUsecase>();
                findCategorisByLevel.Level = level;
                var result = await findCategorisByLevel.Execute();
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

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination([FromQuery]RequestData req)
        {
            try
            {
                var itemPagination = usecaseFactory.Create<PaginatedItemsUsecase>();
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

        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody] ItemSaveDto item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var saveItem = usecaseFactory.Create<SaveItemUsecase>();
                    saveItem.Dto = item;
                    var result = await saveItem.Execute();
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

                var findItem = usecaseFactory.Create<GetItemUsecase>();
                findItem.Id = id;
                var result = await findItem.Execute();
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
        public async Task<IActionResult> Put(int id, [FromBody] ItemSaveDto item)
        {
            try
            {
                if (id < 0)
                {
                    return NotFound();
                }
                if (item == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var updateItem = this.usecaseFactory.Create<UpdateItemUsecase>();
                    updateItem.Id = id;
                    updateItem.Dto = item;
                    var result = await updateItem.Execute();
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
                var deleteItem = usecaseFactory.Create<DeleteItemUsecase>();
                deleteItem.Id = id;
                var result = await deleteItem.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
