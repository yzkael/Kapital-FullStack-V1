using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using src.Contracts.AuthDtos;
using src.Data;
using src.Entities;
using src.Entities.Entities;
using src.Interfaces.IServices;
using src.Mappers;

namespace src.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly AppDbContext _context;

        public AuthServices(UserManager<Usuario> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Result<Usuario?>> Login(LoginRequestDto loginDto)
        {
            Result<Usuario?> result = new();
            result.ResultObject = await _userManager.FindByNameAsync(loginDto.Username);
            if (result.ResultObject == null)
            {
                result.AddError("User was not found");
                return result;
            }
            var passwordMatch = await _userManager.CheckPasswordAsync(result.ResultObject, loginDto.Password);
            if (!passwordMatch)
            {
                result.AddError("Password don't match");
                return result;
            }
            result.Succeded();
            return result;
        }

        public async Task<Result<Usuario?>> Register(RegisterRequestDto registerDto)
        {
            Result<Usuario?> result = new();
            var checkIfCarnetIsUsed = await _context.Personas.FirstOrDefaultAsync(p => p.Carnet == registerDto.Carnet);
            if (checkIfCarnetIsUsed != null)
            {
                result.AddError("Carnet is already being used");
            }
            var checkIfUsernameIsUsed = await _userManager.FindByNameAsync(registerDto.Username);
            if (checkIfUsernameIsUsed != null)
            {
                result.AddError("Username is already being used");
            }
            var checkIfEmailIsUsed = await _userManager.FindByEmailAsync(registerDto.Email);
            if (checkIfEmailIsUsed != null)
            {
                result.AddError("Email is already being used");
            }
            var personaCreated = await _context.Personas.AddAsync(registerDto.FromRegisterRequestDtoToPersona());
            var usuarioCreated = await _userManager.CreateAsync(registerDto.FromRegisterRequestDtoToUsuario(personaCreated.Entity.Id));
            if (!usuarioCreated.Succeeded)
            {
                result.AddError("Error while creating Usuario");
            }
            result.ResultObject = await _userManager.FindByEmailAsync(registerDto.Email);
            if (result.ResultObject == null)
            {
                result.AddError("Error while fetching Usuario");
            }
            var roleAssignated = await _userManager.AddToRoleAsync(result.ResultObject!, registerDto.Role);
            if (!roleAssignated.Succeeded)
            {
                result.AddError("Error while assignating role");
            }

            if (result.Errors.Any())
            {
                return result;
            }
            await _context.SaveChangesAsync();
            result.Succeded();
            return result;
        }
    }
}