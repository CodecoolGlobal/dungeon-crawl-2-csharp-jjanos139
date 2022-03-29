namespace DungeonCrawl.Actors.Static
{
    public class Switch : Actor
    {
        public override int DefaultSpriteId => 482;
        public override string DefaultName => "Switch";

        public override bool Detectable => false;
    }
}