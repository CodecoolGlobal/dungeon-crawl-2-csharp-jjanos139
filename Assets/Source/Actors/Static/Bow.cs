namespace DungeonCrawl.Actors.Static
{
    public class Bow : Actor
    {
        public override int DefaultSpriteId => 325;
        public override string DefaultName => "Bow";

        public override bool Detectable => false;
    }
}