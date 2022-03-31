using UnityEngine;
using System;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class GrassFloor : Actor
    {
        private AudioSource _footStepWoods1;
        private AudioSource _footStepWoods2;
        private AudioSource _footStepWoods3;

        readonly System.Random _randomSound = new System.Random();
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }
        private void InstantiateAudio()
        {
            _footStepWoods1 = Instantiate(Resources.Load<AudioSource>("FootStepWoods1"));
            _footStepWoods2 = Instantiate(Resources.Load<AudioSource>("FootStepWoods2"));
            _footStepWoods3 = Instantiate(Resources.Load<AudioSource>("FootStepWoods3"));
            _footStepWoods1.transform.parent = transform;
            _footStepWoods2.transform.parent = transform;
            _footStepWoods3.transform.parent = transform;
        }
        private void PlayRandomFootStepWoodsSound()
        {
            int soundCase = _randomSound.Next(1, 4);

            switch (soundCase)
            {
                case 1: _footStepWoods1.Play(); break;
                case 2: _footStepWoods2.Play(); break;
                case 3: _footStepWoods3.Play(); break;
            }
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                PlayRandomFootStepWoodsSound(); 
            return true;
        }
        public override int DefaultSpriteId => 0;
        public override string DefaultName => "GrassFloor";

<<<<<<< HEAD
        public override bool Detectable => false;
        public override char DefaultChar => ',';
=======
        public override bool Detectable => true;
>>>>>>> development
    }
}