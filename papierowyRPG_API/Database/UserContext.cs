using Microsoft.EntityFrameworkCore;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.Database
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Stats> Stats { get; set; }

        private string dbPath;

        public UserContext()
        {
            dbPath = "sqlite.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}
