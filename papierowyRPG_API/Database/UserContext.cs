using Microsoft.EntityFrameworkCore;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.Database
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public string DbPath;

        public UserContext()
        {
            DbPath = "sqlite.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}
