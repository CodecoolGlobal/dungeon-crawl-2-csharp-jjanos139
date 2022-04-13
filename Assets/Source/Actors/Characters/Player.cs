using System;
using UnityEngine;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        protected override void InstantiateAudio(string _, string __)
        {
            DeathSound1 = Instantiate(Resources.Load<AudioSource>("DeathSound1"));
            DeathSound2 = Instantiate(Resources.Load<AudioSource>("DeathSound2"));
            DeathSound3 = Instantiate(Resources.Load<AudioSource>("DeathSound3"));
            DeathSound1.transform.parent = transform;
            DeathSound2.transform.parent = transform;
            DeathSound3.transform.parent = transform;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            //TODO Play enemy character's attack sound.
            ActorManager.Singleton.IsCombat = true;
            battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
            return true;
        }

        private void Awake()
        {
            base.Awake();

            SpriteRenderer = GetComponent<SpriteRenderer>();

            SetSprite(DefaultSpriteId);

            CameraController.Singleton.Camera.transform.parent = this.transform;
            CameraController.Singleton.Position = (0, 0);

            _fieldOfView = Instantiate(Resources.Load<FieldOfView>("FieldOfView"));
            _fieldOfView.transform.parent = this.transform;
            _fieldOfView.SetOrigin(transform.position);
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                battleSystem.HandleActionSelection();
            }

            if (!ActorManager.Singleton.IsCombat)
            {
                // Move up
                if (Input.GetKeyDown(KeyCode.W))
                {
                    // Move up
                    TryMove(Direction.Up);
                    _turnCounter = 0;
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    // Move down
                    TryMove(Direction.Down);
                    _turnCounter = 0;
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    // Move left
                    TryMove(Direction.Left);
                    _turnCounter = 0;
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    // Move right
                    TryMove(Direction.Right);
                    _turnCounter = 0;
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
                        this.Health += ItemUnder.Health;
                        this.MaxHealth += ItemUnder.Health;
                        this.Damage += ItemUnder.Damage;
                        ActorManager.Singleton.DestroyActor(ItemUnder);
                    }
                }

                if (Input.GetKey(KeyCode.I))
                {
                    var canvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
                    canvas.enabled = true;
                    var contents = GameObject.Find("Contents").GetComponent<Text>();
                    string contentsOfBag = "";
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        contentsOfBag += $"{Inventory[i].DefaultName}\n";
                    }

                    contents.text = contentsOfBag;
                }
                else
                {
                    var canvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
                    canvas.enabled = false;
                }
                _fieldOfView.SetOrigin(transform.position);
            }
        }

        private void PlayRandomDeathSound()
        {
            int soundCase = Utilities.GetRandomInt(1, 4);

            switch (soundCase)
            {
                case 1: DeathSound1.Play(); break;
                case 2: DeathSound2.Play(); break;
                case 3: DeathSound3.Play(); break;
            }
        }

        protected override void OnDeath()
        {
            PlayRandomDeathSound();
            Debug.Log("Oh no, I'm dead!");
        }

        private AudioSource DeathSound1;
        private AudioSource DeathSound2;
        private AudioSource DeathSound3;
        private FieldOfView _fieldOfView;
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
