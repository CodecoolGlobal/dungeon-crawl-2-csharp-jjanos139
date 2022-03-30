namespace DungeonCrawl.Actors.Static
{
    public class RoadHorizontal : Actor
    {
        public override int DefaultSpriteId => 60;
        public override string DefaultName => "RoadHorizontal";

        public override bool Detectable => false;
    }
}