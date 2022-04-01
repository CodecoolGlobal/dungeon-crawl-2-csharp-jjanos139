using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class IronDoor : Actor
    {
        public override int DefaultSpriteId => 194;
        public override string DefaultName => "IronDoor";
        public override int Z => -1;

        Actor _actorKey1 = ActorManager.Singleton.GetActorAt((19, -11));
        Actor _actorKey2 = ActorManager.Singleton.GetActorAt((78, -2));
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Soul")
            {
                return true;
            }
            else if (anotherActor.Inventory.Contains(_actorKey1) && this.Position ==(80, -16))
                return true;
            else if (anotherActor.Inventory.Contains(_actorKey2) && this.Position == (14, -26))
                return true;
            return false;
        }

        public override char DefaultChar => '8';
    }
}