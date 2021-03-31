using Business.Abstract;
using Entities;
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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetRentalById(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(RentalUpdateDto rental)
        {
            var result = _rentalService.Update(rental);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("rent")]
        [Authorize]
        public IActionResult Rent(RentalAddDto rentalAddDto)
        {

            var result = _rentalService.Add(rentalAddDto);

            if (!result.IsSuccess)
                BadRequest(result.Message);

            return Ok(result.Message);

        }

        [HttpPut("deliver")]
        [Authorize]
        public IActionResult Deliver(RentalDeliverDto rentalDeliverDto)
        {
            var result = _rentalService.Deliver(rentalDeliverDto);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
