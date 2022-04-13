namespace DungeonCrawl.Actors.Static
{
    public class Bush : Actor
    {
        public override int DefaultSpriteId => 96;
        public override string DefaultName => "Bush";
        public override int Z => -1;
        public override char DefaultChar => 'z';
        
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}