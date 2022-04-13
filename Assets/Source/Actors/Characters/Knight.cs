using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Knight : Character
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
                if (_turnCounter >= 0.8)
                {
                    _turnCounter = 0;
                    (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                    CheckIfAggro(playerCoords, 4, 6);

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

        protected override void OnDeath()
        {
            DeathSound.Play();
            Debug.Log("How...?");
        }

        private float _turnCounter;
        public override string AttackSoundFileName => "PriestSound";
        public override string DeathSoundFileName => "DeathSound3";
        public override int DefaultSpriteId => 30;
        public override string DefaultName => "Knight";
        public override int Health
        {
            get;
            set;
        } = 170;

        public override int MaxHealth => 170;
        public override int Damage => 15;
        public override char DefaultChar => '/';
    }
}