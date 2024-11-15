namespace papierowyRPG_API.Models
{
    public class Character
    {
        public int Id { get; set; }
        public int Id_user { get; set; }
        public int Id_game { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string story { get; set; }
        public int Id_stats { get; set; }

    }
}
