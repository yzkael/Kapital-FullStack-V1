using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Contracts.AuthDtos
{
    public record LoginRequestDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "Usuario demasido corto")]
        public string Username { get; init; } = null!;
        [Required]
        [MinLength(6, ErrorMessage = "Contrasenha demasiado corta")]
        public string Password { get; init; } = null!;
    }
}