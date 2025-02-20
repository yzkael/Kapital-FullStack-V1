using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Configurations.Options
{
    public class RolesData
    {
        public const string Section = "RolesData";
        public string AdminId { get; set; } = null!;
        public string UsuarioId { get; set; } = null!;
        public string EmpleadoId { get; set; } = null!;
    }
}