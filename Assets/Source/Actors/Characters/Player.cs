using UnityEngine;
using Assets.Source.Core;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        private AudioSource DeathSound1;
        private AudioSource DeathSound2;
        private AudioSource DeathSound3;

        readonly System.Random _randomSound = new System.Random();
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }
        private void InstantiateAudio()
        {
            DeathSound1 = Instantiate(Resources.Load<AudioSource>("DeathSound1"));
            DeathSound2 = Instantiate(Resources.Load<AudioSource>("DeathSound2"));
            DeathSound3 = Instantiate(Resources.Load<AudioSource>("DeathSound3"));
            DeathSound1.transform.parent = transform;
            DeathSound2.transform.parent = transform;
            DeathSound3.transform.parent = transform;
        }

        private void PlayRandomDeathSound()
        {
            int soundCase = _randomSound.Next(1, 4);

            switch (soundCase)
            {
                case 1: DeathSound1.Play(); break;
                case 2: DeathSound2.Play(); break;
                case 3: DeathSound3.Play(); break;
            }
        }

        BattleSystem battleSystem = new BattleSystem();
        public override bool OnCollision(Actor anotherActor)
        {
            battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
            return true;
        }


        protected override void OnUpdate(float deltaTime)
        {
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                InCombat = true;
                battleSystem.HandleActionSelection();
                InCombat = false;
            }

            // Move up
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
            }

            if (Input.GetKey(KeyCode.W))
            {
                // Move down
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.25)
                {
                    TryMove(Direction.Up);
                    _turnCounter = 0;
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                // Move down
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.25)
                {
                    TryMove(Direction.Down);
                    _turnCounter = 0;
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                // Move left
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.25)
                {
                    TryMove(Direction.Left);
                    _turnCounter = 0;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                // Move right
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.25)
                {
                    TryMove(Direction.Right);
                    _turnCounter = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                // pick up item
                if (ItemUnder != null)
                {
                    UserInterface.Singleton.SetText(null, UserInterface.TextPosition.BottomRight);
                    this.Inventory.Add(ItemUnder);
                    ActorManager.Singleton.DestroyActor(ItemUnder);
                }
            }
        }


        protected override void OnDeath()
        {
            PlayRandomDeathSound();
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";

        public override int Health
        {
            get;
            set;
        } = 1000;

        public override int MaxHealth => 1000;

        public override int Damage => 15;

        private float _turnCounter;
    }
}
