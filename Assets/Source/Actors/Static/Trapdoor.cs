using Assets.Source.Actors.Static;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Static
{
    public class Trapdoor : Traversable
    {
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
                else if (MapLoader.AllActorsSecondMap != null && this.Position == (49, -22))
                {
                    ActorManager.Singleton.FreezeActualMap(1);
                    ActorManager.Singleton.DestroyAllActors();
                    MapLoader.ReLoadMap(2);
                    anotherActor.Position = (4, -17);
                }
                else if (this.Position == (8, -6))
                {
                    ActorManager.Singleton.FreezeActualMap(3);
                    ActorManager.Singleton.DestroyAllActors();
                    MapLoader.ReLoadMap(2);
                    anotherActor.Position = (54, -23);
                }
            }
            AttackSound.Play();
            return false;
        }

        public override string AttackSoundFileName => "Sounds/MapTwoMusic";
        public override int DefaultSpriteId => 731;
        public override string DefaultName => "Trapdoor";
        public override int Z => -1;
        public override char DefaultChar => 'n';
    }
}