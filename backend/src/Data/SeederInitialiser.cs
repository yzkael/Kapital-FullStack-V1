using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using src.Configurations.Options;
using src.Entities.Entities;

namespace src.Data
{
    public static class InitializeExtension
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<SeederInitialiser>();

            await initialiser.InitialiseAsync();

            await initialiser.TrySeedAsync();

        }
    }


    public class SeederInitialiser
    {
        private readonly ILogger<SeederInitialiser> _logger;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly SudoData _sudoData;

        public SeederInitialiser(AppDbContext context, RoleManager<IdentityRole> roleManager, UserManager<Usuario> userManager, ILogger<SeederInitialiser> logger, IOptions<SudoData> sudoData)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
            _sudoData = sudoData.Value;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error while trying to Initialise the Database {ex.Message}");
                throw;
            }

        }

        public async Task TrySeedAsync()
        {
            try
            {
                var newPersona = new Persona
                {
                    Nombre = _sudoData.InformacionPersonal.Nombre,
                    ApellidoPaterno = _sudoData.InformacionPersonal.ApellidoPaterno,
                    ApellidoMaterno = _sudoData.InformacionPersonal.ApellidoMaterno,
                    Carnet = _sudoData.InformacionPersonal.Carnet,
                    Telefono = _sudoData.InformacionPersonal.Telefono
                };
                if (await _context.Personas.FirstOrDefaultAsync(p => p.Carnet == _sudoData.InformacionPersonal.Carnet) == null)
                {
                    await _context.Personas.AddAsync(newPersona);
                }
                var personaId = await _context.Personas.Where(p => p.Carnet == _sudoData.InformacionPersonal.Carnet).Select(p => p.Id).FirstOrDefaultAsync();
                var passwordHasher = new PasswordHasher<Usuario>();
                var newUsuario = new Usuario
                {
                    UserName = _sudoData.Username,
                    PasswordHash = passwordHasher.HashPassword(null!, _sudoData.Password),
                    Email = _sudoData.Email,
                    PersonaId = personaId == Guid.Empty ? newPersona.Id : personaId
                };
                if (await _userManager.Users.FirstOrDefaultAsync(u => u.Email == _sudoData.Email) == null)
                {
                    await _userManager.CreateAsync(newUsuario);
                }
                var newRole = new IdentityRole
                {
                    Name = "Sudo",
                    NormalizedName = "SUDO"
                };
                if (await _roleManager.FindByNameAsync(newRole.Name) == null)
                {
                    await _roleManager.CreateAsync(newRole);
                }
                var usuario = await _userManager.FindByNameAsync(_sudoData.Username);
                if (usuario == null)
                {
                    if (await _userManager.IsInRoleAsync(newUsuario!, newRole.Name))
                    {
                        await _userManager.AddToRoleAsync(newUsuario, newRole.Name);
                    }
                }
                else
                {
                    await _userManager.AddToRoleAsync(usuario, newRole.Name);

                }
                await _context.SaveChangesAsync();

            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error while trying to Seed the database: {ex.Message}");
                throw;
            }
        }

    }
}