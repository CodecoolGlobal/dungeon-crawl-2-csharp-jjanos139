using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ogre : Character
    {
        BattleSystem battleSystem = new BattleSystem();

        private AudioSource _ogreSound;
        private AudioSource _ogreDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _ogreSound = Instantiate(Resources.Load<AudioSource>("OgreSound"));
            _ogreSound.transform.parent = transform;
            _ogreDeathSound = Instantiate(Resources.Load<AudioSource>("OgreDeathSound"));
            _ogreDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _ogreSound.Play();
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
            _ogreDeathSound.Play();
            Debug.Log("ME SMASH!");
        }

        public override int DefaultSpriteId => 317;
        public override string DefaultName => "Ogre";

        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;
        public override char DefaultChar => 'r';
    }
}