namespace papierowyRPG_API.Models
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; 
        public bool IsActive { get; set; }
        public string Ruleset { get; set; } = null!;
        public int PlayerAmount { get; set; }

    }
}
