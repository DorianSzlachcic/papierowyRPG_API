﻿namespace papierowyRPG_API.Models
{
    public class Notes
    {
        public int ID { get; set; }
        public string Note { get; set; }
        public int CharacterId {  get; set; }
        public Character Character { get; set; } = null!;
    }
}
