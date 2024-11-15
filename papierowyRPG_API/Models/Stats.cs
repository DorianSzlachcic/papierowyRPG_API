namespace papierowyRPG_API.Models
{
    public class Stats
    {
        public int ID { get; set; }
        public Character Character { get; set; } = null!;
        public Skills Skills { get; set; } = null!;
        public Items Items{ get; set; } = null!;
        public string[] stats { get; set; }
    }
}
