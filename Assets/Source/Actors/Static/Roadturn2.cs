﻿using UnityEngine;
using Assets.Source.Actors.Static;

namespace DungeonCrawl.Actors.Static
{
    public class RoadTurn2 : Traversable
    {
        protected override void InstantiateAudio(string _, string __)
        {
            FootStepCity1 = Instantiate(Resources.Load<AudioSource>("Sounds/FootStepCity1"));
            FootStepCity2 = Instantiate(Resources.Load<AudioSource>("Sounds/FootStepCity2"));
            FootStepCity3 = Instantiate(Resources.Load<AudioSource>("Sounds/FootStepCity3"));
            FootStepCity1.transform.parent = transform;
            FootStepCity2.transform.parent = transform;
            FootStepCity3.transform.parent = transform;
        }

        private void PlayRandomFootStepCitySound()
        {
            int soundCase = Utilities.GetRandomIntBetween(1, 4);

            switch (soundCase)
            {
                case 1: FootStepCity1.Play(); break;
                case 2: FootStepCity2.Play(); break;
                case 3: FootStepCity3.Play(); break;
            }
        }

        public void OnTriggerEnter2D(Collider2D collider2D)
        {
            PlayRandomFootStepCitySound();
        }

        private AudioSource FootStepCity1;
        private AudioSource FootStepCity2;
        private AudioSource FootStepCity3;
        public override int DefaultSpriteId => 12;
        public override string DefaultName => "RoadTurn2";
        public override bool IsWalkable => true;
        public override char DefaultChar => 'ß';
        public override bool Detectable => false;
    }
}