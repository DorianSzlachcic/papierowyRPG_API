using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services
{
    public interface IGameService
    {
        public List<GameDTO>? GetGames();
    }
}
