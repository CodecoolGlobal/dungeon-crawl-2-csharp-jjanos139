using UnityEngine;
using System;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public AudioSource DeathSound1;
        public AudioSource DeathSound2;
        public AudioSource DeathSound3;
        public AudioSource FootStepWoods1;
        public AudioSource FootStepWoods2;
        public AudioSource FootStepWoods3;

        readonly System.Random _randomSound = new System.Random();
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }
        void InstantiateAudio()
        {
            DeathSound1 = Instantiate(Resources.Load<AudioSource>("DeathSound1"));
            DeathSound2 = Instantiate(Resources.Load<AudioSource>("DeathSound2"));
            DeathSound3 = Instantiate(Resources.Load<AudioSource>("DeathSound3"));
            DeathSound1.transform.parent = transform;
            DeathSound2.transform.parent = transform;
            DeathSound3.transform.parent = transform;
            FootStepWoods1 = Instantiate(Resources.Load<AudioSource>("FootStepWoods1"));
            FootStepWoods2 = Instantiate(Resources.Load<AudioSource>("FootStepWoods2"));
            FootStepWoods3 = Instantiate(Resources.Load<AudioSource>("FootStepWoods3"));
            FootStepWoods1.transform.parent = transform;
            FootStepWoods2.transform.parent = transform;
            FootStepWoods3.transform.parent = transform;
        }

        void PlayRandomDeathSound()
        {
            int soundCase = _randomSound.Next(1, 4);

            switch (soundCase)
            {
                case 1: DeathSound1.Play(); break;
                case 2: DeathSound2.Play(); break;
                case 3: DeathSound3.Play(); break;
            }
        }
        void PlayRandomFootStepWoodsSound()
        {
            int soundCase = _randomSound.Next(1, 4);

            switch (soundCase)
            {
                case 1: FootStepWoods1.Play(); break;
                case 2: FootStepWoods2.Play(); break;
                case 3: FootStepWoods3.Play(); break;
            }
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
                PlayRandomFootStepWoodsSound();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
                PlayRandomFootStepWoodsSound();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
                PlayRandomFootStepWoodsSound();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
                PlayRandomFootStepWoodsSound();
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
