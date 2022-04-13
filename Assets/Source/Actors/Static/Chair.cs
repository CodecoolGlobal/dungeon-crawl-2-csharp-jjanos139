namespace DungeonCrawl.Actors.Static
{
    public class Chair : Actor
    {
        public override int DefaultSpriteId => 392;
        public override string DefaultName => "Chair";
        public override int Z => -1;
        public override char DefaultChar => 'Ü';
        
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}