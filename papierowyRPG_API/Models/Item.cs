namespace papierowyRPG_API.Models
{
    public class Item
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatsId { get; set; }
        public Stats? Stats { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; } = null!;
    }
}
