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
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                InCombat = true;
                battleSystem.HandleActionSelection();
            }

            if (!InCombat)
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

        private float _turnCounter;

        private AudioSource _spiderSound;
        private AudioSource _spiderDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _spiderSound = Instantiate(Resources.Load<AudioSource>("SpiderSound"));
            _spiderSound.transform.parent = transform;
            _spiderDeathSound = Instantiate(Resources.Load<AudioSource>("SpiderDeathSound"));
            _spiderDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {

            if (anotherActor is Player)
            {
                _spiderSound.Play();
                battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
                return true;
            }
            return false;
        }

        protected override void OnDeath()
        {
            _spiderDeathSound.Play();
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