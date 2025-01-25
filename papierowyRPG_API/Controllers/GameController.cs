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

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(string name, string ruleset, string player1, string player2, string player3, string player4, string gameMaster)
        {
            var test = gameService.CreateGame(name, ruleset, gameMaster, player1, player2, player3, player4);
            return test == null ? BadRequest() : Ok(test);
        }

        [HttpGet("games")]
        [ProducesResponseType<List<GameDTO>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Games(string name)
        {
            var test = gameService.GetGamesForPlayer(name);
            return test == null ? BadRequest() : Ok(test);
        }
    }
}
