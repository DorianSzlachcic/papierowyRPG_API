namespace papierowyRPG_API.Models
{
    public class User
    {
        public int ID { get; set; }
        public ICollection<Character> Character { get; } = new List<Character>();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
