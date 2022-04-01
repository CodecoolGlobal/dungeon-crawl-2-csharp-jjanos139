﻿using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Bear : Character
    {
        private AudioSource _bearSound;
        private AudioSource _bearDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _bearSound = Instantiate(Resources.Load<AudioSource>("BearSound"));
            _bearSound.transform.parent = transform;
            _bearDeathSound = Instantiate(Resources.Load<AudioSource>("BearDeathSound"));
            _bearDeathSound.transform.parent = transform;
        }

        BattleSystem battleSystem = new BattleSystem();

        //protected override void OnUpdate(float deltaTime)
        //{
        //    if (battleSystem.state == BattleStatus.PlayerMove)
        //    {
        //        battleSystem.HandleActionSelection();
        //    }
        //    _turnCounter += deltaTime;
        //    if (_turnCounter >= 1)
        //    {
        //        _turnCounter = 0;
        //        (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
        //        Direction direction = GetRandomDirection();
        //        TryMove(direction);
        //    }
        //}

        public override bool OnCollision(Actor anotherActor)
        {

            if (anotherActor is Player)
            {
                _bearSound.Play();
                battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
                return true;
            }
            return false;
        }

        protected override void OnDeath()
        {
            _bearDeathSound.Play();
            Debug.Log("It's because I'm smarter than the average bear.");
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                InCombat = true;
                battleSystem.HandleActionSelection();
            }

            if (!InCombat)
            {
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.5)
                {
                    _turnCounter = 0;
                    (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                    CheckIfAggro(playerCoords, 1000, 2000);

                    if (_isAggro)
                    {
                        var placeToMove = PathFind(playerCoords);
                        if (placeToMove != (0, 0))
                            TryMove(placeToMove);
                        else
                        {
                            Direction direction = GetRandomDirection();
                            TryMove(direction);
                        }
                    }
                    else if (!_isAggro)
                    {
                        Direction direction = GetRandomDirection();
                        TryMove(direction);
                    }
                }
            }
        }

        private float _turnCounter;
        public override int DefaultSpriteId => 413;
        public override string DefaultName => "Bear";

        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;

        public override bool Detectable => true;

        public override char DefaultChar => 'B';
    }
}