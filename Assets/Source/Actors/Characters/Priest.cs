using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Priest : Character
    {
        protected override void OnUpdate(float deltaTime)
        {
            _turnCounter += deltaTime;
            if (_turnCounter >= 1)
            {
                _turnCounter = 0;
                (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                Direction direction = GetRandomDirection();
                TryMove(direction);
            }
        }
        private float _turnCounter;
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Finally. Descension.");
        }

        public override int DefaultSpriteId => 78;
        public override string DefaultName => "Priest";
    }
}