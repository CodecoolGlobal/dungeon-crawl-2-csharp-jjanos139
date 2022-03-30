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
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Well, I was already dead anyway...");
        }

        protected override void OnUpdate(float deltaTime)
        {
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

        public override char DefaultChar => 's';
    }
}
