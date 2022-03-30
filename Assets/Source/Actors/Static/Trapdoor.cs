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
                if (MapLoader.AllActorsSecondMap is null)
                {
                    ActorManager.Singleton.FreezeActualMap(1);
                    ActorManager.Singleton.DestroyAllActors();
                    MapLoader.LoadMap(2);
                    anotherActor.Position = (4, -17);
                }
                else
                {
                    ActorManager.Singleton.FreezeActualMap(1);
                    ActorManager.Singleton.DestroyAllActors();
                    MapLoader.ReLoadMap(2);
                    anotherActor.Position = (4, -17);
                }
            }

            return false;
        }

        public override char DefaultChar => 'n';
    }
}