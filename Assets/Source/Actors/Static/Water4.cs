namespace DungeonCrawl.Actors.Static
{
    public class Water4 : Actor
    {
        public override int DefaultSpriteId => 200;
        public override string DefaultName => "Water4";

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
        public override char DefaultChar => 'm';
    }
}