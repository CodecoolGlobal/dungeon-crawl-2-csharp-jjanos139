namespace DungeonCrawl.Actors.Static
{
    public class Walter : Actor
    {
        public override int DefaultSpriteId => 201;
        public override string DefaultName => "Walter";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
                return false;
            return true;
        }
    }
}