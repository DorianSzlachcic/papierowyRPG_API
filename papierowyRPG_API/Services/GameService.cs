using Microsoft.EntityFrameworkCore;
using papierowyRPG_API.Database;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services
{
    public class GameService(UserContext context) : IGameService, IDisposable
    {
        public List<GameDTO>? GetGames()
        {
            
            return context.Games.Include(x => x.Character).Select(x => new GameDTO
            {
                Id = x.ID,
                Name = x.Name,
                IsActive = x.IsActive,
                Ruleset = x.StatsTypeJSON,
                PlayerAmount = x.Character.ToList().Count(),
                GameMaster = x.GameMaster.Username,
            }).ToList();
            
        }

        public List<GameDTO>? GetGamesForPlayer(string name)
        {
            UserService service = new UserService(context);
            var user = service.GetUser(name);

            
            var games = from character in context.Characters
                        where character.User == user
                        select character.Game;

            
            List<GameDTO> returnable = games
                .Select(game => new GameDTO
                {
                    Id = game.ID,
                    Name = game.Name,
                    IsActive = game.IsActive,
                    Ruleset = game.StatsTypeJSON, 
                    PlayerAmount = game.Character.Count(), 
                    GameMaster = game.GameMaster.Username
                })
                .ToList();
            returnable.AddRange(context.Games.Where(x => x.GameMaster == user).Select(game => new GameDTO
            {
                Id = game.ID,
                Name = game.Name,
                IsActive = game.IsActive,
                Ruleset = game.StatsTypeJSON,
                PlayerAmount = game.Character.Count(),
                GameMaster = game.GameMaster.Username
            })
                .ToList());


            return returnable;
        }

        public bool? CreateGame(string name, string ruleset, string gameMaster, string player1, string player2, string player3, string player4)
        {
            UserService userros = new(context);
            
            User gameMasterr = userros.GetUser(gameMaster);
            Game game = new Game { IsActive = false, GameMaster = gameMasterr, Name = name, StatsTypeJSON = ruleset };
            if (gameMasterr == null)
                return null;

            context.Attach(gameMasterr);
            game.GameMaster = gameMasterr;
            context.Add(game);
            try { context.SaveChanges(); } catch { return null; }

            var players = new List<User?>
            {
                userros.GetUser(player1),
                userros.GetUser(player2),
                userros.GetUser(player3),
                userros.GetUser(player4)
            };

            

            List<int> statValues;
            switch (game.StatsTypeJSON)
            {
                case "D&D":
                    statValues = new List<int> { 0, 0, 0, 0, 0, 0 };
                    break;
                case "SPECIAL":
                    statValues = new List<int> { 0, 0, 0, 0, 0, 0, 0 };
                    break;
                case "GURPS":
                    statValues = new List<int> { 0, 0, 0, 0 };
                    break;
                default:
                    return null; 
            }

            foreach (var player in players)
            {
                if (player == null) continue;
               

                var stats = new Stats { StatValues = statValues.ToArray() };
                context.Add(stats);
                try { context.SaveChanges(); } catch { return null; }

                var character = new Character
                {
                    User = player,
                    Game = game,
                    Name = "",
                    Description = "",
                    Story = "",
                    Stats = stats
                };

                context.Add(character);
            }

            try { context.SaveChanges(); } catch { return null; }

            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}
