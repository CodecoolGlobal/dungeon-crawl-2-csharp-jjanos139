﻿using UnityEngine;
using System;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class RoadHorizontal : Actor
    {
        private AudioSource FootStepCity1;
        private AudioSource FootStepCity2;
        private AudioSource FootStepCity3;

        readonly System.Random _randomSound = new System.Random();
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }
        private void InstantiateAudio()
        {
            FootStepCity1 = Instantiate(Resources.Load<AudioSource>("FootStepCity1"));
            FootStepCity2 = Instantiate(Resources.Load<AudioSource>("FootStepCity2"));
            FootStepCity3 = Instantiate(Resources.Load<AudioSource>("FootStepCity3"));
            FootStepCity1.transform.parent = transform;
            FootStepCity2.transform.parent = transform;
            FootStepCity3.transform.parent = transform;
        }
        private void PlayRandomFootStepCitySound()
        {
            int soundCase = _randomSound.Next(1, 4);

            switch (soundCase)
            {
                case 1: FootStepCity1.Play(); break;
                case 2: FootStepCity2.Play(); break;
                case 3: FootStepCity3.Play(); break;
            }
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                PlayRandomFootStepCitySound();
            return true;
        }
        public override int DefaultSpriteId => 60;
        public override string DefaultName => "RoadHorizontal";
        public override char DefaultChar => '{';
        public override bool IsWalkable => true;
        public override bool Detectable => true;
    }
}