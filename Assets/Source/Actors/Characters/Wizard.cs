using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Wizard : Character
    {
        BattleSystem battleSystem = new BattleSystem();
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _wizardSound.Play();

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

        private AudioSource _wizardSound;
        private AudioSource _wizardDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _wizardSound = Instantiate(Resources.Load<AudioSource>("WizardSound"));
            _wizardSound.transform.parent = transform;
            _wizardDeathSound = Instantiate(Resources.Load<AudioSource>("DeathSound1"));
            _wizardDeathSound.transform.parent = transform;
        }

        protected override void OnDeath()
        {
            _wizardDeathSound.Play();
            Debug.Log("Run, you fool.");
        }

        public override int DefaultSpriteId => 457;
        public override string DefaultName => "Wizard";
        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;

        public override char DefaultChar => 'v';
    }
}