namespace DungeonCrawl.Actors.Static
{
    public class Water : Actor
    {
        public override int DefaultSpriteId => 247;
        public override string DefaultName => "Water";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
                return false;
            return true;
        }
        public override char DefaultChar => 'W';
    }
}