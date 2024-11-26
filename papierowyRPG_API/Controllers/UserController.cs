using Microsoft.AspNetCore.Mvc;
using papierowyRPG_API.Models;
using papierowyRPG_API.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace papierowyRPG_API.Controllers
{
    public class LoginForm
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class RegisterForm : LoginForm
    {
        public required string Email { get; set; }
    }

    [Route("api/users")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<List<User>>(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(userService.GetUsers());
        }

        [HttpPost("login")]
        [ProducesResponseType<User>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromForm] LoginForm loginForm)
        {
            User? user = userService.AuthenticateUser(loginForm.Username, loginForm.Password);
            return user == null ? Unauthorized() : Ok(user);
        }

        [HttpPost("register")]
        [ProducesResponseType<User>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Register([FromForm] RegisterForm registerForm)
        {
            User newUser = new User
            {
                Username = registerForm.Username,
                Password = registerForm.Password,
                Email = registerForm.Email
            };
            User? user = userService.RegisterUser(newUser);
            return user == null ? Unauthorized() : Ok(user);
        }
    }
}
