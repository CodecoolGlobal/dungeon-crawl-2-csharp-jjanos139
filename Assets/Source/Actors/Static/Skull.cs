namespace DungeonCrawl.Actors.Static
{
    public class Skull : Actor
    {
        public override int DefaultSpriteId => 719;
        public override string DefaultName => "Skull";
        public override int Z => -1;
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        public override char DefaultChar => 'Ú';
    }
}