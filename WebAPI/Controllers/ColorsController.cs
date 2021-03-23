using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _colorService.Get((short)id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Data);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();

            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result.Data);

        } 

        [HttpPost]
        public IActionResult Add(string colorName)
        {
            var result = _colorService.Add(new Color { Name = colorName });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);//TODO return Created action result
        }

        [HttpPut]
        public IActionResult Update(Color updatedColor)
        {
            var result = _colorService.Update(updatedColor);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _colorService.Delete((short)id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
