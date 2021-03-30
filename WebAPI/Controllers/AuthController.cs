using Business.Abstract;
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
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userForLoginResult = _authService.Login(userForLoginDto);
            if (!userForLoginResult.IsSuccess)
            {
                return BadRequest(userForLoginResult.Message);
            }

            var result = _authService.CreateAccessToken(userForLoginResult.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExistsResult = _authService.UserExists(userForRegisterDto.Email);
            if (userExistsResult.Data)
            {
                return BadRequest(userExistsResult.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            if (!registerResult.IsSuccess)
            {
                return BadRequest(registerResult.Message);
            }
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);

        }
    }
}
