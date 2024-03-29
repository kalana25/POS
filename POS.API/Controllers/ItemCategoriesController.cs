﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using POS.UseCases.DTO;
using POS.Core.Interfaces;
using POS.Core.General;
using POS.UseCases.General.ItemCategories.DeleteItemCategory;
using POS.UseCases.General.ItemCategories.GetItemCategories;
using POS.UseCases.General.ItemCategories.GetItemCategoriesByLevel;
using POS.UseCases.General.ItemCategories.GetItemCategoriesByParentAndLevel;
using POS.UseCases.General.ItemCategories.GetItemCategory;
using POS.UseCases.General.ItemCategories.PaginatedItemCategories;
using POS.UseCases.General.ItemCategories.SaveItemCategory;
using POS.UseCases.General.ItemCategories.UpdateItemCategory;
using POS.UseCases.General.ItemCategories.GetNextItemCategoryCode;

namespace POS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoriesController : ControllerBase
    {
        private readonly IUseCaseFactory usecaseFactory;

        public ItemCategoriesController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagination([FromQuery]RequestData req)
        {
            try
            {
                var categoryPagination = usecaseFactory.Create<PaginatedItemCategoriesUsecase>();
                categoryPagination.RequestData = req;
                var result = await categoryPagination.Execute();
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

        [HttpGet("find/next/code")]
        public async Task<IActionResult> GetNextItemCategoryCode()
        {
            try
            {
                var nextCategory = usecaseFactory.Create<GetNextItemCategoryCodeUsecase>();
                var result = await nextCategory.Execute();
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


        [HttpGet("findall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var findItemCategories = usecaseFactory.Create<GetItemCategoriesUsecase>();
                var result = await findItemCategories.Execute();
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
                var findCategorisByLevel = usecaseFactory.Create<GetItemCategoriesByLevelUsecase>();
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

        [HttpGet("findall/parent/{parent}/level/{level}")]
        public async Task<IActionResult> GetAllByParentAndLevel(int parent, int level)
        {
            try
            {
                var findCategorisByParentLevel = usecaseFactory.Create<GetItemCategoriesByParentAndLevel>();
                findCategorisByParentLevel.Level = level;
                findCategorisByParentLevel.Parent = parent;
                var result = await findCategorisByParentLevel.Execute();
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
        public async Task<IActionResult> Post([FromBody] ItemCategorySaveDto itemCategory)
        {
            try
            {
                if (itemCategory == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var saveItemCategory = usecaseFactory.Create<SaveItemCategoryUsecase>();
                    saveItemCategory.Dto = itemCategory;
                    var result = await saveItemCategory.Execute();
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

                var findItemCategory = usecaseFactory.Create<GetItemCategoryUsecase>();
                findItemCategory.Id = id;
                var result = await findItemCategory.Execute();
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
        public async Task<IActionResult> Put(int id, [FromBody] ItemCategorySaveDto itemCategory)
        {
            try
            {
                if (id < 0)
                {
                    return NotFound();
                }
                if (itemCategory == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var updateItemCategory = this.usecaseFactory.Create<UpdateItemCategoryUsecase>();
                    updateItemCategory.Id = id;
                    updateItemCategory.Dto = itemCategory;
                    var result = await updateItemCategory.Execute();
                    return Ok(result);
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
                var deleteItemCategory = usecaseFactory.Create<DeleteItemCategoryUsecase>();
                deleteItemCategory.Id = id;
                var result = await deleteItemCategory.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
