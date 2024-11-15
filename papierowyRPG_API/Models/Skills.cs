namespace papierowyRPG_API.Models
{
    public class Skills
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int id_s { get; set; }
        public Notes? Notes { get; set; }
        public int id_c { get; set; }
        public Character Character { get; set; } = null!;
    }
}
