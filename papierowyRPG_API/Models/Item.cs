namespace papierowyRPG_API.Models
{
    public class Item
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int StatsId { get; set; }
        public Stats? Stats { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; } = null!;
    }
}
