using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Demon : Character
    {

        BattleSystem battleSystem = new BattleSystem();
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                _demonSound.Play();
                battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
                return true;
            }
            return false;
        }
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
                if (_turnCounter >= 0.5)
                {
                    _turnCounter = 0;
                    (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                    CheckIfAggro(playerCoords, 4, 10);

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
        }
        private float _turnCounter;

        private AudioSource _demonSound;
        private AudioSource _demonDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _demonSound = Instantiate(Resources.Load<AudioSource>("DemonSound"));
            _demonSound.transform.parent = transform;
            _demonDeathSound = Instantiate(Resources.Load<AudioSource>("DemonDeathSound"));
            _demonDeathSound.transform.parent = transform;
        }

        protected override void OnDeath()
        {
            _demonDeathSound.Play();
            Debug.Log("Burn!!!");
        }

        public override int DefaultSpriteId => 122;
        public override string DefaultName => "Demon";
        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;

        public override char DefaultChar => '!';
    }
}