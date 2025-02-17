using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            Result<Usuario?> loginRequest = await _authServices.Login(loginDto);
            if (!loginRequest.IsSuccessful)
            {
                BadRequest("Wrong Username or Password");
            }
            return Ok();
        }
    }
}