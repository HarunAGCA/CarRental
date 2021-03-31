using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileHelper;
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
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        ICarImageService _carImageService;

        public CarsController(ICarService carService, ICarImageService carImageService)
        {
            _carService = carService;
            _carImageService = carImageService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCarDto carDto)
        {

            var result = _carService.Add(carDto);

            if (result.IsSuccess == true)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int Id)
        {
            var result = _carService.Delete(Id);
            if (result.IsSuccess == true)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(UpdateCarDto car)
        {
            var result = _carService.Update(car);
            if (result.IsSuccess == true)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.IsSuccess == true)
            {
                return Ok(result.Data);

            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.IsSuccess == true)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }

        [HttpPost("Images/add")]
        [Authorize]
        public IActionResult AddImage([FromForm] AddCarImageDto addCarImageDto)
        {

            var result = _carImageService.Add(addCarImageDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);

        }

        [HttpDelete("images/delete/{id}")]
        [Authorize]
        public IActionResult DeleteImage(int id)
        {
            var result = _carImageService.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPut("images/update")]
        [Authorize]
        public IActionResult UpdateImage([FromForm] UpdateCarImageDto updateCarImageDto)
        {
            var result = _carImageService.Update(updateCarImageDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpGet("images/byCarId/{carid}")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetAllByCarId(carId);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);

        }
        [HttpGet("images/byId/{id}")]
        public IActionResult GetImageById(int id)
        {
            var result = _carImageService.GetById(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }



    }
}

