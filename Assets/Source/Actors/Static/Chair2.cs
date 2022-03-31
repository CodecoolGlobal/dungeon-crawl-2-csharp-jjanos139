namespace DungeonCrawl.Actors.Static
{
    public class Chair2 : Actor
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
        public override int DefaultSpriteId => 393;
        public override string DefaultName => "Chair2";
        public override int Z => -1;

        public override char DefaultChar => '*';
    }
}