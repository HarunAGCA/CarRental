using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Get(short id)
        {
            var result = _colorService.Get(id);

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
        [Authorize]
        public IActionResult Add(string colorName)
        {
            var result = _colorService.Add(new ColorAddDto { Name = colorName });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(ColorUpdateDto updatedColor)
        {
            var result = _colorService.Update(new ColorUpdateDto { Id = updatedColor.Id, Name = updatedColor.Name });
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(short id)
        {
            var result = _colorService.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
