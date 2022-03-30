namespace DungeonCrawl.Actors.Static
{
    public class Water3 : Actor
    {
        public override int DefaultSpriteId => 199;
        public override string DefaultName => "Water3";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
                return false;
            return true;
        }
        public override char DefaultChar => 'V';
    }
}