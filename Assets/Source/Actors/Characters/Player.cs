using UnityEngine;
using System;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public AudioSource _deathSound1;
        public AudioSource _deathSound2;
        public AudioSource _deathSound3;

        System.Random randomSound = new System.Random();
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }
        void InstantiateAudio()
        {
            _deathSound1 = Instantiate(Resources.Load<AudioSource>("DeathSound1"));
            _deathSound2 = Instantiate(Resources.Load<AudioSource>("DeathSound2"));
            _deathSound3 = Instantiate(Resources.Load<AudioSource>("DeathSound3"));
            _deathSound1.transform.parent = transform;
            _deathSound2.transform.parent = transform;
            _deathSound3.transform.parent = transform;
        }

        void PlayAudio()
        {
            int soundCase = randomSound.Next(1, 4);

            switch (soundCase)
            {
                case 1: _deathSound1.Play(); break;
                case 2: _deathSound2.Play(); break;
                case 3: _deathSound3.Play(); break;
            }
        }

            
        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            PlayAudio();
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        
    }
}
