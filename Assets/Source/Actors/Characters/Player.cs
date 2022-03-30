using UnityEngine;
using System;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        private AudioSource DeathSound1;
        private AudioSource DeathSound2;
        private AudioSource DeathSound3;

        readonly System.Random _randomSound = new System.Random();
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }
        private void InstantiateAudio()
        {
            DeathSound1 = Instantiate(Resources.Load<AudioSource>("DeathSound1"));
            DeathSound2 = Instantiate(Resources.Load<AudioSource>("DeathSound2"));
            DeathSound3 = Instantiate(Resources.Load<AudioSource>("DeathSound3"));
            DeathSound1.transform.parent = transform;
            DeathSound2.transform.parent = transform;
            DeathSound3.transform.parent = transform;
        }

        private void PlayRandomDeathSound()
        {
            int soundCase = _randomSound.Next(1, 4);

            switch (soundCase)
            {
                case 1: DeathSound1.Play(); break;
                case 2: DeathSound2.Play(); break;
                case 3: DeathSound3.Play(); break;
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
            PlayRandomDeathSound();
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        
    }
}
