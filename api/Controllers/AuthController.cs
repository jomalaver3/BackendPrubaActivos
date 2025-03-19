using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using activosBackend.Models;
using Entidades;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace activosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            try
            {
                var user = MapToUser(model);

                var result = await _authService.RegisterAsync(user);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel model)
        {
            try
            {
                var user = MapToUser(model);

                var token = await _authService.LoginAsync(user);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        private User MapToUser(UserModel model)
        {
            return new User
            {
                Id = model.Id,
                Username = model.Username,
                PasswordHash = model.Password,
            };
        }
    }
}
