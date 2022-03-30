namespace DungeonCrawl.Actors.Static
{
    public class Campfire : Actor
    {
        public override int DefaultSpriteId => 493;
        public override string DefaultName => "Campfire";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
                return false;
            return true;
        }

        public override char DefaultChar => 't';
    }
}