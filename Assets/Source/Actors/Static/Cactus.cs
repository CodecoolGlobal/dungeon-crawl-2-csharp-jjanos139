namespace DungeonCrawl.Actors.Static
{
    public class Cactus : Actor
    {
        public override int DefaultSpriteId => 53;
        public override string DefaultName => "Cactus";

        public override bool Detectable => false;
    }
}