using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Battleaxe : Actor
    {
        private AudioSource _itemPickUp;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _itemPickUp = Instantiate(Resources.Load<AudioSource>("ItemPickUp"));
            _itemPickUp.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _itemPickUp.Play();
            return true;
        }

        public override int DefaultSpriteId => 376;
        public override string DefaultName => "Battleaxe";
        public override int Z => -1;


        public override bool Detectable => false;

        public override char DefaultChar => '=';
    }
}