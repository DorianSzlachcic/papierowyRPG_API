using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services
{
    public interface IGameService
    {
        public List<GameDTO>? GetGames();
        public bool? CreateGame(string name, string ruleset, string gameMaster, string player1, string player2, string player3, string player4);
    }
}
