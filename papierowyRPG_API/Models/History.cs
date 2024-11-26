namespace papierowyRPG_API.Models
{
    public class History
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public required string Note { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
    }
}
