using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class LastBoss : Character
    {
        BattleSystem battleSystem = new BattleSystem();
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                _lastBossSound.Play();
                battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
                return true;
            }
            return false;
        }

        private AudioSource _lastBossSound;
        private AudioSource _victory;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _lastBossSound = Instantiate(Resources.Load<AudioSource>("LastBossSound"));
            _lastBossSound.transform.parent = transform;
            _victory = Instantiate(Resources.Load<AudioSource>("Victory"));
            _victory.transform.parent = transform;
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
            _victory.Play();
            Debug.Log("I will return!");
        }

        public override int DefaultSpriteId => 455;
        public override string DefaultName => "LastBoss";

        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;
        public override char DefaultChar => '§';
    }
}