﻿using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Demon : Character
    {
        protected override void OnUpdate(float deltaTime)
        {
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                battleSystem.HandleActionSelection();
            }

            if (!ActorManager.Singleton.IsCombat)
            {
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.5)
                {
                    _turnCounter = 0;
                    (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                    CheckIfAggro(playerCoords, 4, 10);

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
        }
        private float _turnCounter;
        public override string AttackSoundFileName => "DemonSound";
        public override string DeathSoundFileName => "DemonDeathSound";
        protected override void OnDeath()
        {
            DeathSound.Play();
            Debug.Log("Burn!!!");
        }
        public override int DefaultSpriteId => 122;
        public override string DefaultName => "Demon";
        public override int Health
        {
            get;
            set;
        } = 100;
        public override int MaxHealth => 225;
        public override int Damage => 25;
        public override char DefaultChar => '!';
    }
}