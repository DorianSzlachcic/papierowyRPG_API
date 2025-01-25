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
                Ruleset = x.StatsTypeJSON[0],
                PlayerAmount = x.Character.ToList().Count(),
            }).ToList();
            
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
