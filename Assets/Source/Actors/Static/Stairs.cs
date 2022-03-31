﻿using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Stairs : Actor
    {
        private AudioSource _mapOneMusic;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _mapOneMusic = Instantiate(Resources.Load<AudioSource>("MapOneMusic"));
            _mapOneMusic.transform.parent = transform;
        }
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
                    _mapOneMusic.Play();
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
                    _mapOneMusic.Play();
                    MapLoader.ReLoadMap(3);
                    anotherActor.Position = (7, -6);
                }
                    
            }

            return false;
        }

        public override char DefaultChar => 'ú';
    }
}