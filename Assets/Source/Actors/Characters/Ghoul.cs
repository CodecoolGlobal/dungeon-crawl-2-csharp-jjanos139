using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghoul : Character
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
                if (_turnCounter >= 1)
                {
                    _turnCounter = 0;
                    (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                    CheckIfAggro(playerCoords, 2, 5);

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
            Debug.Log("Zoinks! G-G-G-G-Ghost");
        }

        private float _turnCounter;
        public override string AttackSoundFileName => "Sounds/GhoulSound";
        public override string DeathSoundFileName => "Sounds/GhoulDeathSound";
        public override int DefaultSpriteId => 315;
        public override string DefaultName => "Ghoul";
        public override int Health
        {
            get;
            set;
        } = 100;
        public override int MaxHealth => 150;
        public override int Damage => 10;
        public override char DefaultChar => 'g';
    }
}