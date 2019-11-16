using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgendaWeb.Repositories;

namespace AgendaWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<UnitOfWork,Model> : Controller where UnitOfWork:IUnitOfWork where Model:class
    {
        private readonly IUnitOfWork unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        //[HttpGet("findall")]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        var result = await unitOfWork.
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //[HttpGet("find/{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        if (id < 1)
        //        {
        //            return BadRequest();
        //        }
        //        var result = await repository.Get(id);
        //        if (result == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        if (id < 1)
        //        {
        //            return NotFound();
        //        }
        //        var objectToDelete = await repository.Get(id);
        //        repository.Remove(objectToDelete);

        //        // save changes
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
    }
}
