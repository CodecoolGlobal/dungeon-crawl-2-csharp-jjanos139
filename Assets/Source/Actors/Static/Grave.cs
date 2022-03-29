namespace DungeonCrawl.Actors.Static
{
    public class Grave : Actor
    {
        public override int DefaultSpriteId => 672;
        public override string DefaultName => "Grave";

        public override bool Detectable => false;
    }
}