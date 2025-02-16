using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entities.Entities;

namespace src.Configurations.Options
{
    public class SudoData
    {
        public const string Section = "SudoData";
        public Persona InformacionPersonal { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}