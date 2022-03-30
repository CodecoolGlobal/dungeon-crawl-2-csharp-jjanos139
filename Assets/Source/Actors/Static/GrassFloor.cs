using UnityEngine;
using System;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class GrassFloor : Actor
    {
        private AudioSource FootStepWoods1;
        private AudioSource FootStepWoods2;
        private AudioSource FootStepWoods3;

        readonly System.Random _randomSound = new System.Random();
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }
        private void InstantiateAudio()
        {
            FootStepWoods1 = Instantiate(Resources.Load<AudioSource>("FootStepWoods1"));
            FootStepWoods2 = Instantiate(Resources.Load<AudioSource>("FootStepWoods2"));
            FootStepWoods3 = Instantiate(Resources.Load<AudioSource>("FootStepWoods3"));
            FootStepWoods1.transform.parent = transform;
            FootStepWoods2.transform.parent = transform;
            FootStepWoods3.transform.parent = transform;
        }
        private void PlayRandomFootStepWoodsSound()
        {
            int soundCase = _randomSound.Next(1, 4);

            switch (soundCase)
            {
                case 1: FootStepWoods1.Play(); break;
                case 2: FootStepWoods2.Play(); break;
                case 3: FootStepWoods3.Play(); break;
            }
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                PlayRandomFootStepWoodsSound(); return true;
        }
        public override int DefaultSpriteId => 0;
        public override string DefaultName => "GrassFloor";

        public override bool Detectable => true;
    }
}