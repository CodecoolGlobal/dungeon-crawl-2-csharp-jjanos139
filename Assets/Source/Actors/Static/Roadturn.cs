namespace DungeonCrawl.Actors.Static
{
    public class RoadTurn : Actor
    {
        public override int DefaultSpriteId => 8;
        public override string DefaultName => "RoadTurn";

        public override bool Detectable => false;
    }
}