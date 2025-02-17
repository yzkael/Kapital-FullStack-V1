using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using src.Contracts.AuthDtos;
using src.Entities;
using src.Entities.Entities;
using src.Interfaces.IServices;

namespace src.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<Usuario> _userManager;

        public AuthServices(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<Usuario?>> Login(LoginRequestDto loginDto)
        {
            Result<Usuario?> result = new();
            result.ResultObject = await _userManager.FindByNameAsync(loginDto.Username);
            if (result.ResultObject == null)
            {
                result.AddError("User was not found");
                return result;
            }
            var passwordMatch = await _userManager.CheckPasswordAsync(result.ResultObject, loginDto.Password);
            if (!passwordMatch)
            {
                result.AddError("Password don't match");
                return result;
            }
            result.Succeded();
            return result;
        }
    }
}