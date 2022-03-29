namespace DungeonCrawl.Actors.Static
{
    public class House : Actor
    {
        public override int DefaultSpriteId => 966;
        public override string DefaultName => "House";
        public override int Z => -1;
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}