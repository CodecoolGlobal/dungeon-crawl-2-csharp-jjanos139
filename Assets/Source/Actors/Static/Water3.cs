namespace DungeonCrawl.Actors.Static
{
    public class Water3 : Actor
    {
        public override int DefaultSpriteId => 199;
        public override string DefaultName => "Water3";

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}