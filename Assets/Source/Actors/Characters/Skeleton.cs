using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;


namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        protected override void OnDeath()
        {
            DeathSound.Play();
            Debug.Log("Well, I was already dead anyway...");
        }

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
        }

        public override string AttackSoundFileName => "SkeletonSound";
        public override string DeathSoundFileName => "SkeletonDeathSound";
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
