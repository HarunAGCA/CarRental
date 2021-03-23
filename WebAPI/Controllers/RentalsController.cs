using Business.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
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
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("rent")]
        public IActionResult Rent(RentalAddDto rentalAddDto)
        {
            var rental = new Rental
            {
                CustomerId = rentalAddDto.CustomerId,
                CarId = rentalAddDto.CarId,
                RentDate = rentalAddDto.RentDate
            };

            var result = _rentalService.Add(rental);

            if (!result.IsSuccess)
                BadRequest(result.Message);

            return Ok(result.Message);

        }

        [HttpPut("deliver")]
        public IActionResult Deliver(RentalDeliverDto rentalDeliverDto)
        {
            var result = _rentalService.Deliver(rentalDeliverDto);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
