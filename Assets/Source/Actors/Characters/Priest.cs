using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Priest : Character
    {

        BattleSystem battleSystem = new BattleSystem();

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
                (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                Direction direction = GetRandomDirection();
                TryMove(direction);
            }
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                battleSystem.HandleActionSelection();
            }
        }
        private float _turnCounter;

        private AudioSource _priestSound;
        private AudioSource _priestDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _priestSound = Instantiate(Resources.Load<AudioSource>("PriestSound"));
            _priestSound.transform.parent = transform;
            _priestDeathSound = Instantiate(Resources.Load<AudioSource>("DeathSound2"));
            _priestDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                _priestSound.Play();
                battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
                return true;
            }
            return false;
        }

        protected override void OnDeath()
        {
            _priestDeathSound.Play();
            Debug.Log("Finally. Descension.");
        }

        public override int DefaultSpriteId => 78;
        public override string DefaultName => "Priest";

        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;
        public override char DefaultChar => '%';
    }
}