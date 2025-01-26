using Microsoft.AspNetCore.Mvc;
using papierowyRPG_API.Forms;
using papierowyRPG_API.Models;
using papierowyRPG_API.Services;

namespace papierowyRPG_API.Controllers
{
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var user = userService.GetUser(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost("login")]
        [ProducesResponseType<User>(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromForm] LoginForm loginForm)
        {
            User? user = userService.AuthenticateUser(loginForm);
            return user == null ? Unauthorized() : Accepted(user);
        }

        [HttpPost("register")]
        [ProducesResponseType<User>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public IActionResult Register([FromForm] RegisterForm registerForm)
        {
            User? user = userService.RegisterUser(registerForm);
            return user != null ?
                CreatedAtAction(nameof(Get), new { id = user.ID }, user.ID) :
                UnprocessableEntity();
        }

        [HttpGet("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id) 
        {
            return userService.DeleteUser(id) == null ? BadRequest() : Ok();
        }
    }
}
