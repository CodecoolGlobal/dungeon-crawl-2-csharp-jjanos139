namespace DungeonCrawl.Actors.Static
{
    public class Fireplace : Actor
    {
        public override int DefaultSpriteId => 868;
        public override string DefaultName => "Fireplace";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
                return false;
            return true;
        }
        public override char DefaultChar => 'T';
    }
}