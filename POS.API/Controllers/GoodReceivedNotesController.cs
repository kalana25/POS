using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using POS.UseCases.DTO;
using POS.Core.Interfaces;
using POS.Core.General;
using System.Security.Claims;
using POS.UseCases.General.GoodReceivedNotes.SaveGoodReceivedNote;
using POS.UseCases.General.GoodReceivedNotes.GetGoodReceivedNote;
using POS.UseCases.General.GoodReceivedNotes.PaginatedGoodReceivedNote;

namespace POS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GoodReceivedNotesController : ControllerBase
    {
        private readonly IUseCaseFactory usecaseFactory;

        public GoodReceivedNotesController(IUseCaseFactory usecaseFactory)
        {
            this.usecaseFactory = usecaseFactory;
        }


        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody] GrnSaveDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var saveGrn = usecaseFactory.Create<SaveGoodReceivedNoteUsecase>();
                    saveGrn.Dto = dto;
                    saveGrn.CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    saveGrn.CreatedByName = User.FindFirst(ClaimValueTypes.Email).Value;
                    var result = await saveGrn.Execute();
                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
                }
                return BadRequest();
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

                var findGrn = usecaseFactory.Create<GetGoodReceivedNoteUsecase>();
                findGrn.Id = id;
                var result = await findGrn.Execute();
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
                var grnPagination = usecaseFactory.Create<PaginatedGoodReceivedNoteUsecase>();
                grnPagination.RequestData = req;
                var result = await grnPagination.Execute();
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