using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Datos.Context;
using Entidades;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

namespace LogicaNegocio.Services
{
    public class AuthS : IAuthService
    {
        private readonly contextDb _context;
        private readonly IConfiguration _config;

        public AuthS(contextDb context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string> RegisterAsync(User request)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Username == request.Username);
            if (userExists) throw new InvalidOperationException("Usuario ya existe.");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);
            var user = new User { Username = request.Username, PasswordHash = hashedPassword };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "Usuario registrado exitosamente.";
        }


        public async Task<bool> UserExists(string request)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Username == request);
            if (userExists) return true;
            return false;          
        }


        public async Task<string> LoginAsync(User request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.PasswordHash, user.PasswordHash))
                throw new UnauthorizedAccessException("Credenciales inválidas.");

            var token = GenerateJwtToken(user);
            return token;
        }

        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                _config["JwtSettings:Issuer"],
                _config["JwtSettings:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["JwtSettings:ExpiryMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}