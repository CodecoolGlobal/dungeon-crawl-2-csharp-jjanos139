using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Bear : Character
    {
        private AudioSource _bearSound;
        private AudioSource _bearDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _bearSound = Instantiate(Resources.Load<AudioSource>("BearSound"));
            _bearSound.transform.parent = transform;
            _bearDeathSound = Instantiate(Resources.Load<AudioSource>("BearDeathSound"));
            _bearDeathSound.transform.parent = transform;
        }
        BattleSystem battleSystem = new BattleSystem();
        public override bool OnCollision(Actor anotherActor)
        {
            BattleSystem battleSystem = new BattleSystem();
            battleSystem.SetupBattle(413, this, anotherActor);
            if (anotherActor is Player)
                _bearSound.Play();
            
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
            _bearDeathSound.Play();
            Debug.Log("It's because I'm smarter than the average bear.");
        }

        public override int DefaultSpriteId => 413;
        public override string DefaultName => "Bear";

        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;


        public override bool Detectable => true;

        public override char DefaultChar => 'B';
    }
}