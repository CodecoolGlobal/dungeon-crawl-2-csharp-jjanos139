namespace DungeonCrawl.Actors.Static
{
    public class Table : Actor
    {

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        public override int DefaultSpriteId => 234;
        public override string DefaultName => "Table";
        public override int Z => -1;

        public override char DefaultChar => 'U';
    }
}