using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Spider : Character
    {

        BattleSystem battleSystem = new BattleSystem();

        protected override void OnUpdate(float deltaTime)
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
        }
        private float _turnCounter;

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
        }
        protected override void OnDeath()
        {
            Debug.Log("Remember, with great power comes great responsibility...");
        }

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