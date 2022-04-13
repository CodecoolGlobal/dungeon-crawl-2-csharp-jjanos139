using Assets.Source.Actors.Static;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Stairs : Traversable
    {
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
            {
                if (this.Position == (3, -17))
                {
                    ActorManager.Singleton.FreezeActualMap(2);
                    ActorManager.Singleton.DestroyAllActors();
                    AttackSound.Play();
                    MapLoader.ReLoadMap(1);
                    anotherActor.Position = (48, -22);
                }
                else if (MapLoader.AllActorsThirdNMap is null)
                {
                    ActorManager.Singleton.FreezeActualMap(2);
                    ActorManager.Singleton.DestroyAllActors();
                    MapLoader.LoadMap(3);
                    anotherActor.Position = (7, -6);
                }
                else if (MapLoader.AllActorsThirdNMap != null && this.Position == (53, -23))
                {
                    ActorManager.Singleton.FreezeActualMap(2);
                    ActorManager.Singleton.DestroyAllActors();
                    MapLoader.ReLoadMap(3);
                    anotherActor.Position = (7, -6);
                }
            }
            return false;
        }

        public override string AttackSoundFileName => "MapOneMusic";
        public override int DefaultSpriteId => 289;
        public override string DefaultName => "Stairs";
        public override int Z => -1;
        public override char DefaultChar => 'ú';
    }
}