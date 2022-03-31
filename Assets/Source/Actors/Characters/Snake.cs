using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Snake : Character
    {

        BattleSystem battleSystem = new BattleSystem();
        public override bool OnCollision(Actor anotherActor)
        {

            battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);

        private AudioSource _snakeSound;
        private AudioSource _snakeDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _snakeSound = Instantiate(Resources.Load<AudioSource>("SnakeSound"));
            _snakeSound.transform.parent = transform;
            _snakeDeathSound = Instantiate(Resources.Load<AudioSource>("SnakeDeathSound"));
            _snakeDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _snakeSound.Play();

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
            _snakeDeathSound.Play();
            Debug.Log("Trust in me...");
        }

        public override int DefaultSpriteId => 411;
        public override string DefaultName => "Snake";

        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;
        public override char DefaultChar => 'S';

        public override bool Detectable => true;

    }
}