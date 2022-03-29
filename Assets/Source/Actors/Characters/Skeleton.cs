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
                Direction direction = GetRandomDirection();
                TryMove(direction);
            }
        }


        private float _turnCounter;
        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";
    }
}
