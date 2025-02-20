using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Contracts.AuthDtos
{
    public record RegisterRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "El nombre es muy corto")]
        public string Nombre { get; init; } = null!;

        [Required]
        [MinLength(2, ErrorMessage = "El apellido paterno es muy corto")]
        public string ApellidoPaterno { get; init; } = null!;

        [Required]
        [MinLength(2, ErrorMessage = "El apellido materno es muy corto")]
        public string ApellidoMaterno { get; init; } = null!;

        [Required]
        [MinLength(10, ErrorMessage = "El carnet es muy corto")]
        public string Carnet { get; init; } = null!;
        public string? Telefono { get; init; }

        [Required]
        [MinLength(4, ErrorMessage = "El username es muy corto")]
        public string Username { get; init; } = null!;

        [Required]
        [MinLength(6, ErrorMessage = "La contrasenha debe ser de 6 caracteres minimo")]
        public string Password { get; init; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; init; } = null!;

        [Required]
        public string Role { get; set; } = null!;
    }
}