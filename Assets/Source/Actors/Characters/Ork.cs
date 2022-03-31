using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ork : Character
    {
        BattleSystem battleSystem = new BattleSystem();

        private AudioSource _orcSound;
        private AudioSource _orcDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _orcSound = Instantiate(Resources.Load<AudioSource>("OrkSound"));
            _orcSound.transform.parent = transform;
            _orcDeathSound = Instantiate(Resources.Load<AudioSource>("OrkDeathSound"));
            _orcDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                _orcSound.Play();
                battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
                return true;
            }
            return false;
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
            _orcDeathSound.Play();
            Debug.Log("Looks like meat is back on the menu boys.");
        }

        public override int DefaultSpriteId => 124;
        public override string DefaultName => "Ork";

        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;
        public override char DefaultChar => 'O';
    }
}