using UnityEngine;
using System;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Floor : Actor
    {
        private AudioSource FootStepCave1;
        private AudioSource FootStepCave2;
        private AudioSource FootStepCave3;

        readonly System.Random _randomSound = new System.Random();
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }
        private void InstantiateAudio()
        {
            FootStepCave1 = Instantiate(Resources.Load<AudioSource>("FootStepCave1"));
            FootStepCave2 = Instantiate(Resources.Load<AudioSource>("FootStepCave2"));
            FootStepCave3 = Instantiate(Resources.Load<AudioSource>("FootStepCave3"));
            FootStepCave1.transform.parent = transform;
            FootStepCave2.transform.parent = transform;
            FootStepCave3.transform.parent = transform;
        }
        private void PlayRandomFootStepCaveSound()
        {
            int soundCase = _randomSound.Next(1, 4);

            switch (soundCase)
            {
                case 1: FootStepCave1.Play(); break;
                case 2: FootStepCave2.Play(); break;
                case 3: FootStepCave3.Play(); break;
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                PlayRandomFootStepCaveSound(); return true;
        }

        public override int DefaultSpriteId => 106;
        public override string DefaultName => "Floor";

        public override bool Detectable => true;
    }
}
