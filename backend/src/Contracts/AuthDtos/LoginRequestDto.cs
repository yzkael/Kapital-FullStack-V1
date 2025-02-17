using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Contracts.AuthDtos
{
    public record LoginRequestDto
    {
        public string Username { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}