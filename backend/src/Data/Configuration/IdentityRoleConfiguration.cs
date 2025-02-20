using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using src.Configurations.Options;

namespace src.Data.Configuration
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private readonly RolesData _rolesData;

        public IdentityRoleConfiguration(IOptions<RolesData> rolesData)
        {
            _rolesData = rolesData.Value;
        }

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            List<IdentityRole<string>> roles = new List<IdentityRole<string>>()
            {
                new IdentityRole<string>
                {
                    Id= _rolesData.UsuarioId,
                    Name="Usuario",
                    NormalizedName = "USUARIO"
                },

                new IdentityRole<string>
                {
                    Id=_rolesData.AdminId,
                    Name="Admin",
                    NormalizedName = "ADMIN"
                },

                new IdentityRole<string>
                {
                    Id=_rolesData.EmpleadoId,
                    Name="Empleado",
                    NormalizedName = "EMPLEADO"
                },
            };
            builder.HasData(roles);
        }
    }
}