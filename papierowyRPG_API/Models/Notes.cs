namespace papierowyRPG_API.Models
{
    public class Notes
    {
        public int ID { get; set; }
        public string note { get; set; }
        public int id_c {  get; set; }
        public Character Character { get; set; } = null!;
    }
}
