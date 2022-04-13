namespace DungeonCrawl.Actors.Static
{
    public class Water2 : Actor
    {
        public override int DefaultSpriteId => 203;
        public override string DefaultName => "Water2";
        public override char DefaultChar => 'w';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}