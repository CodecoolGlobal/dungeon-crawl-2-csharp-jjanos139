﻿using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;


namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {

        BattleSystem battleSystem = new BattleSystem();
        public override bool OnCollision(Actor anotherActor)
        {

            battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);

        private AudioSource _skeletonSound;
        private AudioSource _skeletonDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _skeletonSound = Instantiate(Resources.Load<AudioSource>("SkeletonSound"));
            _skeletonSound.transform.parent = transform;
            _skeletonDeathSound = Instantiate(Resources.Load<AudioSource>("SkeletonDeathSound"));
            _skeletonDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _skeletonSound.Play();

            return true;
        }


        protected override void OnDeath()
        {
            _skeletonDeathSound.Play();
            Debug.Log("Well, I was already dead anyway...");
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                battleSystem.HandleActionSelection();
            }
            _turnCounter += deltaTime;
            if (_turnCounter >= 1)
            {
                _turnCounter = 0;
                (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                CheckIfAggro(playerCoords, 3, 5);

                if (_isAggro)
                {
                    TryMove(GetMoveDirection(playerCoords));
                }
                else if (!_isAggro)
                {
                    Direction direction = GetRandomDirection();
                    TryMove(direction);
                }
            }
        }
        
        private float _turnCounter;
        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";

        public override int Health
        {
            get;
            set;
        } = 100;
        public override int MaxHealth => 100;

        public override int Damage => 10;
        public override char DefaultChar => 's';

        public override bool Detectable => true;

    }
}
