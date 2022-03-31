using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Crocodile : Character
    {

        BattleSystem battleSystem = new BattleSystem();

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                _crocSound.Play();
                battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
                return true;
            }

            return false;
        }

        private AudioSource _crocSound;
        private AudioSource _crocDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _crocSound = Instantiate(Resources.Load<AudioSource>("CrocSound"));
            _crocSound.transform.parent = transform;
            _crocDeathSound = Instantiate(Resources.Load<AudioSource>("CrocDeathSound"));
            _crocDeathSound.transform.parent = transform;
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
            _crocDeathSound.Play();
            Debug.Log("Get on the right side of the road you pelican!");
        }

        public override int DefaultSpriteId => 412;
        public override string DefaultName => "Crocodile";
        public override int Health
        {
            get;
            set;
        } = 40;

        public override int MaxHealth => 40;

        public override int Damage => 10;

        public override char DefaultChar => 'c';
    }
}