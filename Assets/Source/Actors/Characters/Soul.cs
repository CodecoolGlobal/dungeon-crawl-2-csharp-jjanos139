using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Soul : Character
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
                if (_turnCounter >= 0.6)
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

        protected override void OnDeath()
        {
            DeathSound.Play();
            Debug.Log("Woosh.");
        }

        private float _turnCounter;
        public override string AttackSoundFileName => "GhoulSound";
        public override string DeathSoundFileName => "GhoulDeathSound";
        public override int DefaultSpriteId => 314;
        public override string DefaultName => "Soul";
        public override int Health
        {
            get;
            set;
        } = 100;
        public override int MaxHealth => 100;
        public override int Damage => 10;
        public override char DefaultChar => '"';
    }
}