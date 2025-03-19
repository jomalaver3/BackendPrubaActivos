using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Interfaces;

namespace LogicaNegocio.Services
{
    public class DataSeeder
    {
        private readonly IAuthService _authService;

        public DataSeeder(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task SeedAsync()
        {
            if (!await _authService.UserExists("admin@activos.com"))
            {
                await _authService.RegisterAsync(new User
                {
                    Username = "admin@activos.com",
                    PasswordHash = "Admin123!",
                });
            }

            if (!await _authService.UserExists("user@activos.com"))
            {
                await _authService.RegisterAsync(new User
                {
                    Username = "user@activos.com",
                    PasswordHash = "User123!",
                });
            }
        }
    }
}
