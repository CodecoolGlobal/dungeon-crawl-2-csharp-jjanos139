﻿using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Snake : Character
    {
        private AudioSource _snakeSound;
        private AudioSource _snakeDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _snakeSound = Instantiate(Resources.Load<AudioSource>("SnakeSound"));
            _snakeSound.transform.parent = transform;
            _snakeDeathSound = Instantiate(Resources.Load<AudioSource>("SnakeDeathSound"));
            _snakeDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _snakeSound.Play();
            return true;
        }

        protected override void OnDeath()
        {
            _snakeDeathSound.Play();
            Debug.Log("Trust in me...");
        }

        public override int DefaultSpriteId => 411;
        public override string DefaultName => "Snake";
        public override bool Detectable => true;
    }
}