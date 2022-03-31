namespace DungeonCrawl.Actors.Static
{
    public class Tent : Actor
    {
        public override int DefaultSpriteId => 966;
        public override string DefaultName => "Tent";

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        public override char DefaultChar => 'N';
    }
}