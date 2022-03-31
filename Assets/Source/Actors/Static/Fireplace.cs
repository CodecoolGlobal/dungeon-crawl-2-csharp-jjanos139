namespace DungeonCrawl.Actors.Static
{
    public class Fireplace : Actor
    {
        public override int DefaultSpriteId => 868;
        public override string DefaultName => "Fireplace";

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}