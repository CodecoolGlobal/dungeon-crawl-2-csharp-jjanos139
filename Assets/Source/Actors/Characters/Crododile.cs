﻿using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Crocodile : Character
    {
        private AudioSource _crocSound;
        private AudioSource _crocDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _crocSound = Instantiate(Resources.Load<AudioSource>("CrocSound"));
            _crocSound.transform.parent = transform;
            _crocDeathSound = Instantiate(Resources.Load<AudioSource>("CrocDeathSound"));
            _crocDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _crocSound.Play();
            return true;
        }

        protected override void OnDeath()
        {
            _crocDeathSound.Play();
            Debug.Log("Get on the right side of the road you pelican!");
        }

        public override int DefaultSpriteId => 412;
        public override string DefaultName => "Crocodile";
    }
}