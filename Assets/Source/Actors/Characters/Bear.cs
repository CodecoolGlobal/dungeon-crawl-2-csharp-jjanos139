using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Bear : Character
    {
        protected override void OnDeath()
        {
            DeathSound.Play();
            Debug.Log("It's because I'm smarter than the average bear.");
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
        public override string AttackSoundFileName => "Sounds/BearSound";
        public override string DeathSoundFileName => "Sounds/BearDeathSound";
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