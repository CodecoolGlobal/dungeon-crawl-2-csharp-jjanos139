namespace DungeonCrawl.Actors.Static
{
    public class House3 : Actor
    {
        public override int DefaultSpriteId => 1015;
        public override string DefaultName => "House3";
        public override int Z => -1;
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        public override char DefaultChar => 'Ä';
    }
}