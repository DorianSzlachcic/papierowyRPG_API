namespace papierowyRPG_API.Models
{
    public class Character
    {
        public int ID { get; set; }
        public Notes? Notes { get; set; }
        public ICollection<Skills> Skills { get; } = new List<Skills>();
        public ICollection<Items> Items { get; } = new List<Items>();
        public int Id_user { get; set; }
        public User User { get; set; } = null!;
        public int Id_game { get; set; }
        public Game Game { get; set; } = null!;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }
        public int Id_stats { get; set; }
        public Stats? Stats { get; set; }

    }
}
