using Microsoft.EntityFrameworkCore;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.Database
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private string dbPath;

        public UserContext()
        {
            dbPath = "sqlite.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}
