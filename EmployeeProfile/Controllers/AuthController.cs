using EmployeeProfile.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProfile.Controllers
{
    public class AuthController : Controller
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Validate user credentials (this is just a simple example)
            if (login.Username == "test" && login.Password == "password")
            {
                var token = _tokenService.GenerateToken(login.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}