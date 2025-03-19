using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IAuthService
    {
        Task<bool> UserExists(string userDto);

        Task<string> RegisterAsync(User userDto);
        Task<string> LoginAsync(User userDto);
        string GenerateJwtToken(User user);
    }
}
