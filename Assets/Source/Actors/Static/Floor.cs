using UnityEngine;
using System;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Floor : Actor
    {
        private AudioSource _footStepCave1;
        private AudioSource _footStepCave2;
        private AudioSource _footStepCave3;

        readonly System.Random _randomSound = new System.Random();
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }
        private void InstantiateAudio()
        {
            _footStepCave1 = Instantiate(Resources.Load<AudioSource>("FootStepCave1"));
            _footStepCave2 = Instantiate(Resources.Load<AudioSource>("FootStepCave2"));
            _footStepCave3 = Instantiate(Resources.Load<AudioSource>("FootStepCave3"));
            _footStepCave1.transform.parent = transform;
            _footStepCave2.transform.parent = transform;
            _footStepCave3.transform.parent = transform;
        }
        private void PlayRandomFootStepCaveSound()
        {
            int soundCase = _randomSound.Next(1, 4);

            switch (soundCase)
            {
                case 1: _footStepCave1.Play(); break;
                case 2: _footStepCave2.Play(); break;
                case 3: _footStepCave3.Play(); break;
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                PlayRandomFootStepCaveSound();
            return true;
        }

        public override int DefaultSpriteId => 106;
        public override string DefaultName => "Floor";

<<<<<<< HEAD
        public override bool Detectable => false;
        public override char DefaultChar => '.';
=======
        public override bool Detectable => true;
>>>>>>> development
    }
}
