namespace DungeonCrawl.Actors.Static
{
    public class Grave : Actor
    {
        public override int DefaultSpriteId => 672;
        public override string DefaultName => "Grave";
        public override int Z => -1;


        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        public override char DefaultChar => 'G';
    }
}