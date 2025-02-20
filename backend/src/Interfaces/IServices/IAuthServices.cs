using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Contracts.AuthDtos;
using src.Entities;
using src.Entities.Entities;

namespace src.Interfaces.IServices
{
    public interface IAuthServices
    {
        public Task<Result<Usuario?>> Login(LoginRequestDto loginDto);

        public Task<Result<Usuario?>> Register(RegisterRequestDto registerDto);
    }
}