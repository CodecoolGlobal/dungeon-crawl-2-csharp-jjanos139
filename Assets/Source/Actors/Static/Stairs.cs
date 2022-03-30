using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class Stairs : Actor
    {
        public override int DefaultSpriteId => 289;
        public override string DefaultName => "Stairs";
        public override int Z => -1;
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
            {
                if (this.Position == (3, -17))
                {
                    ActorManager.Singleton.FreezeActualMap(2);
                    ActorManager.Singleton.DestroyAllActors();
                    MapLoader.ReLoadMap(1);
                    anotherActor.Position = (48, -22);
                }
            }

            return false;
        }

        public override char DefaultChar => 'ú';
    }
}