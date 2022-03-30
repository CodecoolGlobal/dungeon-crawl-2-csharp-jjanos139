namespace DungeonCrawl.Actors.Static
{
    public class Road : Actor
    {
        public override int DefaultSpriteId => 7;
        public override string DefaultName => "Road";

        public override bool Detectable => false;
    }
}