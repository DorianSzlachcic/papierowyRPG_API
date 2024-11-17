using Microsoft.AspNetCore.Mvc;
using papierowyRPG_API.Models;
using papierowyRPG_API.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace papierowyRPG_API.Controllers
{
    public class LoginForm
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [HttpGet]
        [ProducesResponseType<User>(StatusCodes.Status200OK)]
        public List<User> Get()
        {
            return userService.GetUsers();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] LoginForm loginForm)
        {
            User? user = userService.AuthenticateUser(loginForm.Username, loginForm.Password);
            return user == null ? Unauthorized() : Ok(user);
        }
    }
}
