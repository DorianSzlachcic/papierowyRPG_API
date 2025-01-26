using Microsoft.AspNetCore.Mvc;
using papierowyRPG_API.Models;
using papierowyRPG_API.Services;
using papierowyRPG_API.Forms;

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
        public IActionResult Add([FromForm] GameForm gameForm)
        {
            var test = gameService.CreateGame(gameForm.name, gameForm.ruleset, gameForm.gameMaster, gameForm.player1, gameForm.player2, gameForm.player3, gameForm.player4);
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
