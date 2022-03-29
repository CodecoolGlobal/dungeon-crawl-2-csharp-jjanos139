namespace DungeonCrawl.Actors.Static
{
    public class Stairs : Actor
    {
        public override int DefaultSpriteId => 289;
        public override string DefaultName => "Stairs";
        public override int Z => -1;


        public override bool Detectable => false;
    }
}