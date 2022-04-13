namespace DungeonCrawl.Actors.Static
{
    public class Water : Actor
    {
        public override int DefaultSpriteId => 247;
        public override string DefaultName => "Water";
        public override char DefaultChar => 'W';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}