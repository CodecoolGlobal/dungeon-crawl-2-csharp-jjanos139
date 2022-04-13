using System.Linq;

namespace DungeonCrawl.Actors.Static
{
    public class IronDoor : Actor
    {
        public override int DefaultSpriteId => 194;
        public override string DefaultName => "IronDoor";
        public override int Z => -1;
        public override char DefaultChar => '8';

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Soul")
            {
                return true;
            }
            else if (anotherActor.Inventory.Count(Actor => Actor.DefaultName == "Key") >= 2 && this.Position ==(80, -16))
                return true;
            else if (anotherActor.Inventory.Count(Actor => Actor.DefaultName == "Key") >= 3 && this.Position == (14, -26))
                return true;
            return false;
        }
    }
}