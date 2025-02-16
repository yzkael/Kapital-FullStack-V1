using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Entities.Entities;

namespace src.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasOne(u => u.Persona)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(u => u.PersonaId);
        }
    }
}