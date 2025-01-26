using Microsoft.AspNetCore.Mvc;
using papierowyRPG_API.Models;
using papierowyRPG_API.Services;
using papierowyRPG_API.Forms;

namespace papierowyRPG_API.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController(IGameService gameService, ICharacterService characterService) : ControllerBase
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

        [HttpGet("character")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCharacterForPlayer(int UserId, int GameId)
        {
            var character = characterService.GetCharacter(UserId, GameId);
            return character != null ? Ok(character) : NotFound();
        }
        
        [HttpPost("character")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditCharacter([FromForm] CharacterDTO character)
        {
            var characterEntity = characterService.GetCharacter(character.Id, character.GameId);
            if (characterEntity == null)
                return BadRequest();
            characterEntity.Name = character.Name;
            characterEntity.Description = character.Description;
            characterEntity.Stats.StatValues = character.Stats;
            characterEntity.Story = character.Story;
            if (character.NewItem != null)
                characterEntity.Items.Add(new Item {Character = characterEntity, CharacterId = characterEntity.ID, Description = character.NewItem.Description, Name = character.NewItem.Name, Stats = new Stats {StatValues = character.NewItem.Stats}});
            if (character.NewSkill != null)
                characterEntity.Skills.Add(new Skill {Character = characterEntity, CharacterId = characterEntity.ID, Description = character.NewSkill.Description, Name = character.NewSkill.Name, Stats = new Stats {StatValues = character.NewSkill.Stats}});
            if (character.NewNote != null)
                characterEntity.Notes.Add(new Note {Character = characterEntity, CharacterId = characterEntity.ID, Text = character.NewNote});
            
            var edited = characterService.EditCharacter(characterEntity);
            return edited ? Ok(characterEntity) : BadRequest();
        }
    }
}
