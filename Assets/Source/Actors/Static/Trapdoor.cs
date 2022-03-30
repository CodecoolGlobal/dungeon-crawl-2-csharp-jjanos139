using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class Trapdoor : Actor
    {
        public override int DefaultSpriteId => 731;
        public override string DefaultName => "Trapdoor";
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
            {
                ActorManager.Singleton.DestroyAllActors();
                MapLoader.LoadMap(2);
                anotherActor.Position = (4, -17);
            }

            return false;
        }
    }
}