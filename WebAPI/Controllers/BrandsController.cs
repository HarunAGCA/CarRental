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
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(short id)
        {
            var result = _brandService.Get(id);
            if(!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(short id)
        {
            var result = _brandService.Delete(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(BrandUpdateDto updatedBrand)
        {
            var result = _brandService.Update(updatedBrand);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(string name)
        {
            var result = _brandService.Add(new BrandAddDto { Name = name });
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }


    }
}
