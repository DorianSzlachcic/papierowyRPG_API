using Microsoft.AspNetCore.Mvc;
using papierowyRPG_API.Models;
using papierowyRPG_API.Services;

namespace papierowyRPG_API.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController(IGameService gameService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<List<GameDTO>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            var hold = gameService.GetGames();
            return  hold == null ? BadRequest() : Ok(hold);
        }
    }
}
