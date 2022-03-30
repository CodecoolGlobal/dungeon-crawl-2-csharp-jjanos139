namespace DungeonCrawl.Actors.Static
{
    public class Tent : Actor
    {
        public override int DefaultSpriteId => 966;
        public override string DefaultName => "Tent";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
                return false;
            return true;
        }

        public override char DefaultChar => 'N';
    }
}