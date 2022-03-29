namespace DungeonCrawl.Actors.Static
{
    public class Ring : Actor
    {
        public override int DefaultSpriteId => 332;
        public override string DefaultName => "Ring";

        public override bool Detectable => false;
    }
}