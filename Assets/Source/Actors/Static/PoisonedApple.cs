namespace DungeonCrawl.Actors.Static
{
    public class Apple : Actor
    {
        public override int DefaultSpriteId => 896;
        public override string DefaultName => "Apple";

        public override bool Detectable => false;
    }
}