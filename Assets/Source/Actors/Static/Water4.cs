namespace DungeonCrawl.Actors.Static
{
    public class Water4 : Actor
    {
        public override int DefaultSpriteId => 200;
        public override string DefaultName => "Water4";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
                return false;
            return true;
        }
    }
}