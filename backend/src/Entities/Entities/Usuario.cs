using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace src.Entities.Entities
{
    public class Usuario : IdentityUser
    {
        public Persona Persona { get; set; } = null!;
        public Guid PersonaId { get; set; }
    }
}