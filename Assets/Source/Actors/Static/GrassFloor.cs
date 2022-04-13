using UnityEngine;
using System;
using Assets.Source.Actors.Static;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class GrassFloor : Traversable
    {
        protected override void InstantiateAudio(string _, string __)
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
            int soundCase = Utilities.GetRandomInt(1, 4);

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

        private AudioSource _footStepWoods1;
        private AudioSource _footStepWoods2;
        private AudioSource _footStepWoods3;
        public override int DefaultSpriteId => 0;
        public override string DefaultName => "GrassFloor";
        public override bool IsWalkable => true;
        public override bool Detectable => false;
        public override char DefaultChar => ',';
    }
}