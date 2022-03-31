﻿using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Potion : Actor
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

        public override int DefaultSpriteId => 569;
        public override string DefaultName => "Potion";

        public override bool Detectable => true;
        public override int Z => -1;
    }
}