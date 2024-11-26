namespace papierowyRPG_API.Models
{
    public class Note
    {
        public int ID { get; set; }
        public required string Text { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; } = null!;
    }
}
