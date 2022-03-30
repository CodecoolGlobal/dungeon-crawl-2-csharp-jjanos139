using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        protected override void OnUpdate(float deltaTime)
        {
            // Move up
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
            }

            if (Input.GetKey(KeyCode.W))
            {
                // Move down
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.25)
                {
                    TryMove(Direction.Up);
                    _turnCounter = 0;
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                // Move down
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.25)
                {
                    TryMove(Direction.Down);
                    _turnCounter = 0;
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                // Move left
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.25)
                {
                    TryMove(Direction.Left);
                    _turnCounter = 0;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                // Move right
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.25)
                {
                    TryMove(Direction.Right);
                    _turnCounter = 0;
                }
            }

        }

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        private float _turnCounter;
    }
}
