using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Trapdoor : Actor
    {
        private AudioSource _mapTwoMusic;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _mapTwoMusic = Instantiate(Resources.Load<AudioSource>("MapTwoMusic"));
            _mapTwoMusic.transform.parent = transform;
        }
        public override int DefaultSpriteId => 731;
        public override string DefaultName => "Trapdoor";
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
            {
                ActorManager.Singleton.DestroyAllActors();
                MapLoader.LoadMap(2);
                _mapTwoMusic.Play();
                anotherActor.Position = (4, -17);
            }

            return false;
        }
    }
}