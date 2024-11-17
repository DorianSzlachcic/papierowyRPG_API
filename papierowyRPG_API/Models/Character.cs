namespace papierowyRPG_API.Models
{
    public class Character
    {
        public int ID { get; set; }
        public Notes? Notes { get; set; }
        public ICollection<Skills> Skills { get; } = new List<Skills>();
        public ICollection<Item> Items { get; } = new List<Item>();
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }
        public int StatsId { get; set; }
        public Stats Stats { get; set; }

    }
}
