namespace DungeonCrawl.Actors.Static
{
    public class House2 : Actor
    {
        public override int DefaultSpriteId => 967;
        public override string DefaultName => "House2";
        public override int Z => -1;
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        public override char DefaultChar => 'Ó';
    }
}