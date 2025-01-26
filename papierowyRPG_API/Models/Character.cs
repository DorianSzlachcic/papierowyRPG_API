namespace papierowyRPG_API.Models
{
    public class Character
    {
        public int ID { get; set; }
        public ICollection<Note> Notes { get; set; } = new List<Note>();
        public ICollection<Skill> Skills { get; } = new List<Skill>();
        public ICollection<Item> Items { get; } = new List<Item>();
        public User User { get; set; } = null!;
        public Game Game { get; set; } = null!;
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Story { get; set; }
        public required Stats Stats { get; set; }

    }
}
