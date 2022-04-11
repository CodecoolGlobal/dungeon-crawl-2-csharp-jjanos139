﻿using DungeonCrawl.Core;
using UnityEngine;
using DungeonCrawl;

namespace DungeonCrawl.Actors.Characters
{
    public class Bat : Character
    {
        private AudioSource _batSound;
        private AudioSource _batDeathSound;
        BattleSystem battleSystem = new BattleSystem();
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _batSound = Instantiate(Resources.Load<AudioSource>("BatSound"));
            _batSound.transform.parent = transform;
            _batDeathSound = Instantiate(Resources.Load<AudioSource>("BatDeathSound"));
            _batDeathSound.transform.parent = transform;
        }
        protected override void OnUpdate(float deltaTime)
        {
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                battleSystem.HandleActionSelection();
            }
            _turnCounter += deltaTime;
            if (_turnCounter >= 0.7)
            {
                _turnCounter = 0;
                (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                Direction direction = Utilities.GetRandomDirection();
                TryMove(direction);
            }
        }
        private float _turnCounter;
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                _batSound.Play();
                battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
                return true;
            }
            return false;
        }

        protected override void OnDeath()
        {
            _batDeathSound.Play();
            Debug.Log("I won’t kill you, but I don’t have to save you.");
        }

        public override int DefaultSpriteId => 409;
        public override string DefaultName => "Bat";
        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;

        public override char DefaultChar => 'b';
    }
}