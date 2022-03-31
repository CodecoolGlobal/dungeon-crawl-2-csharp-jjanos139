using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        BattleSystem battleSystem = new BattleSystem();
        public override bool OnCollision(Actor anotherActor)
        {
            battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
            return true;
        }


        protected override void OnUpdate(float deltaTime)
        {
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                battleSystem.HandleActionSelection();
            }
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


        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        public override int Health
        {
            get;
            set;
        } = 1000;

        public override int MaxHealth => 1000;

        public override int Damage => 15;

        private float _turnCounter;
    }
}
