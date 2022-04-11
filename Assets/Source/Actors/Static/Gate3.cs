using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class Gate3 : Actor
    {
        public override int DefaultSpriteId => 434;
        public override string DefaultName => "Gate3";
        public override bool Detectable => true;

        public override char DefaultChar => 'l';

        Actor _actorKey = ActorManager.Singleton.GetActorAt((35, -12));
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.Inventory.Contains(_actorKey))
                return true;

            return false;
        }

    }
}