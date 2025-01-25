namespace papierowyRPG_API.Models
{
    public class Game
    {
        public int ID { get; set; }
        public ICollection<History> History { get; } = new List<History>();
        public ICollection<Character> Character { get; } = new List<Character>();
        public bool IsActive { get; set; }
        public required string Name { get; set; }
        public required string StatsTypeJSON { get; set; }
        public required User GameMaster { get; set; }

    }
}
