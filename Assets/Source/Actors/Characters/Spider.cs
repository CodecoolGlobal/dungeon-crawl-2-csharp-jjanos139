using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Spider : Character
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
                    CheckIfAggro(playerCoords, 4, 5);

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

                if (battleSystem.state == BattleStatus.PlayerMove)
                {
                    battleSystem.HandleActionSelection();
                }
            }
        }

        protected override void OnDeath()
        {
            DeathSound.Play();
            Debug.Log("Remember, with great power comes great responsibility...");
        }

        private float _turnCounter;
        public override string AttackSoundFileName => "Sounds/SpiderSound";
        public override string DeathSoundFileName => "Sounds/SpiderDeathSound";
        public override int DefaultSpriteId => 267;
        public override string DefaultName => "Spider";
        public override int Health
        {
            get;
            set;
        } = 10;
        public override int MaxHealth => 10;
        public override int Damage => 10;
        public override char DefaultChar => 'X';
    }
}