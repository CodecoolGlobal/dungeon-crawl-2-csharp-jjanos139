using System;
using System.Security.Cryptography.X509Certificates;
using DungeonCrawl.Core;
using UnityEditor.AnimatedValues;
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
            return true;
        }


        protected override void OnDeath()
        {
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
                (int x, int y) playerCoords = ActorManager.Singleton.GetPlayerCoords();
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
    }
}
