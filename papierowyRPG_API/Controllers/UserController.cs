using Microsoft.AspNetCore.Mvc;
using papierowyRPG_API.Models;
using papierowyRPG_API.Services;
using System.ComponentModel;

namespace papierowyRPG_API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController
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
    }
}
