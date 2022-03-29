namespace DungeonCrawl.Actors.Static
{
    public class Apple : Actor
    {
        public override int DefaultSpriteId => 896;
        public override string DefaultName => "Apple";
        public override int Z => -1;

        public override bool Detectable => false;
    }
}