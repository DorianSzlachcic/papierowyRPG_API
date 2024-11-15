namespace papierowyRPG_API.Models
{
    public class History
    {
        public int ID { get; set; }
        public int number { get; set; }
        public string note { get; set; }
        public int id_g {  get; set; }
        public Game Game { get; set; } = null!;
    }
}
