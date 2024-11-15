namespace papierowyRPG_API.Models
{
    public class Game
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string[] StatsTypeJSON { get; set; }


        /*
        my idea is that we will receive JSON like:

        {
            strength: 0,
            intelligence: 0,
            charisma: 0
        }

        and turn it to
        string[] StatsTypeJSON {"strength", "intelligence", "charisma"}

        This part will be set up in the creation of the game. Thanks to this addition we can have different types of stats depending on the game
        so you are not limited only to DnD also it shouldn't take much work.

        That variable will be used during adding things to the game like for instance addition of item that will use stats of this schematic or
        new characters. Basically anything that have stats.
         */

    }
}
