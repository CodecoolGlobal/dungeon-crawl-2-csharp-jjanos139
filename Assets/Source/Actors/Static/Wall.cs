namespace DungeonCrawl.Actors.Static
{
    public class Wall : Actor
    {
        public override int DefaultSpriteId => 825;
        public override string DefaultName => "Wall";
        public override char DefaultChar => '#';

        public override bool OnCollision(Actor anotherActor)
        {
            if (DefaultName == "Soul")
            {
                return true;
            }
            return false;
        }
    }
}
