using System.Linq;

namespace DungeonCrawl.Actors.Static
{
    public class Gate3 : Actor
    {
        public override int DefaultSpriteId => 434;
        public override string DefaultName => "Gate3";
        public override bool Detectable => true;
        public override char DefaultChar => 'l';

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.Inventory.Count(Actor => Actor.DefaultName == "Key") >= 1)
                return true;

            return false;
        }
    }
}