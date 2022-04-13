namespace DungeonCrawl.Actors.Static
{
    public class Campfire : Actor
    {
        public override int DefaultSpriteId => 493;
        public override string DefaultName => "Campfire";
        public override char DefaultChar => 't';
        
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}