using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Contracts.AuthDtos;
using src.Entities;
using src.Entities.Entities;
using src.Interfaces.IServices;

namespace src.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly ITokenServices _tokenServices;
        public AuthController(IAuthServices authServices, ITokenServices tokenServices)
        {
            _authServices = authServices;
            _tokenServices = tokenServices;
        }
        [HttpGet]
        [Authorize("SudoRole")]
        public IActionResult Test()
        {
            return Ok();
        }
        [HttpGet]
        [Route("poto")]
        public IActionResult Test1()
        {
            return Ok("Poto prueba");
        }

        [HttpPost]
        [Authorize("SudoRole")]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDto)
        {
            Result<Usuario?> result = await _authServices.Register(registerDto);
            if (result.IsSuccessful == false)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User registered succesfully");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            Result<Usuario?> loginRequest = await _authServices.Login(loginDto);
            if (!loginRequest.IsSuccessful)
            {
                BadRequest("Wrong Username or Password");
            }
            var accessToken = await _tokenServices.CreateAccessTokenAsync(loginRequest.ResultObject!);
            var refreshToken = _tokenServices.CreateRefreshToken(loginRequest.ResultObject!);
            HttpContext.Response.Cookies.Append("refresh_token", refreshToken);
            return Ok(new { AccessToken = accessToken });
        }


    }
}