namespace DungeonCrawl.Actors.Static
{
    public class IronDoor : Actor
    {
        public override int DefaultSpriteId => 194;
        public override string DefaultName => "IronDoor";
        public override int Z => -1;


        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}