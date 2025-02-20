using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Contracts.AuthDtos;
using src.Entities.Entities;

namespace src.Mappers
{
    public static class PersonaMappers
    {
        public static Persona FromRegisterRequestDtoToPersona(this RegisterRequestDto model)
        {
            return new Persona
            {
                Nombre = model.Nombre,
                ApellidoPaterno = model.ApellidoPaterno,
                ApellidoMaterno = model.ApellidoMaterno,
                Carnet = model.Carnet,
                Telefono = model.Telefono ?? "",
            };
        }
    }
}