namespace papierowyRPG_API.Models
{
    public class Stats
    {
        public int ID { get; set; }
        public Character? Character { get; set; }
        public Skills? Skills { get; set; }
        public Item? Items{ get; set; }
        public int[] stats { get; set; }
    }
}
