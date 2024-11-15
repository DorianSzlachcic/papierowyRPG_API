namespace papierowyRPG_API.Models
{
    public class Character
    {
        public int ID { get; set; }
        public Game Game { get; set; } = null!;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }
        public int Id_stats { get; set; }
        public Stats? Stats { get; set; }

    }
}
