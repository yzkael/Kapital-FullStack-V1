using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using src.Contracts.AuthDtos;
using src.Entities.Entities;

namespace src.Mappers
{
    public static class UsuarioMappers
    {
        public static Usuario FromRegisterRequestDtoToUsuario(this RegisterRequestDto model, Guid personaId)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            return new Usuario
            {
                UserName = model.Username,
                PasswordHash = passwordHasher.HashPassword(null!, model.Password),
                Email = model.Email,
                PersonaId = personaId
            };
        }
    }
}