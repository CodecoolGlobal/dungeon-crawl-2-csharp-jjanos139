using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors
{
    public abstract class Actor : MonoBehaviour
    {
        
        public (int x, int y) Position
        {
            get => _position;
            set
            {
                _position = value;
                transform.position = new Vector3(value.x, value.y, Z);
            }
        }

        private (int x, int y) _position;

        protected SpriteRenderer SpriteRenderer;
        //private FieldOfView _fieldOfView;

        protected void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();

            SetSprite(DefaultSpriteId);

            if (this.GetType() == typeof(Player))
            {
                //CameraController.Singleton.Camera.transform.parent = this.transform;
                //CameraController.Singleton.Position = (0, 0);

                //_fieldOfView = Instantiate(Resources.Load<FieldOfView>("FieldOfView"));
                //_fieldOfView.transform.parent = this.transform;

                //SpriteMask spriteMask = Instantiate(Resources.Load<SpriteMask>("Sprite Mask"));
                //spriteMask.transform.parent = this.transform;
                //}

            }
            //SpriteRenderer.maskInteraction = SpriteMaskInteraction.None;
            SpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

            //GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Objects");
        }

        protected virtual void InstantiateAudio(string attackSound, string deathSound)
        {
            AttackSound = Instantiate(Resources.Load<AudioSource>(attackSound));
            AttackSound.transform.parent = transform;
            DeathSound = Instantiate(Resources.Load<AudioSource>(deathSound));
            DeathSound.transform.parent = transform;
        }

        private void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        public void SetSprite(int id)
        {
            SpriteRenderer.sprite = ActorManager.Singleton.GetSprite(id);
        }

        public void TryMove(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition == null)
            {
                // No obstacle found, just move
                MapLoader.PathFinding.GetGrid().GetGridObject(Position.x, Position.y + MapLoader.CurrentMapHeight).isWalkable = true;
                MapLoader.PathFinding.GetGrid().GetGridObject(targetPosition.x, targetPosition.y + MapLoader.CurrentMapHeight).isWalkable = false;
                Position = targetPosition;
            }
            else
            {
                if (actorAtTargetPosition.OnCollision(this))
                {
                    // Allowed to move
                    MapLoader.PathFinding.GetGrid().GetGridObject(Position.x, Position.y + MapLoader.CurrentMapHeight).isWalkable = true;
                    MapLoader.PathFinding.GetGrid().GetGridObject(targetPosition.x, targetPosition.y + MapLoader.CurrentMapHeight).isWalkable = false;
                    Position = targetPosition;
                }
            }
        }

        public void TryMove((int x, int y) targetPosition)
        {
            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition == null)
            {
                // No obstacle found, just move
                MapLoader.PathFinding.GetGrid().GetGridObject(Position.x, Position.y + MapLoader.CurrentMapHeight).isWalkable = true;
                MapLoader.PathFinding.GetGrid().GetGridObject(targetPosition.x, targetPosition.y + MapLoader.CurrentMapHeight).isWalkable = false;
                Position = targetPosition;
            }
            else
            {
                if (actorAtTargetPosition.OnCollision(this))
                {
                    // Allowed to move
                    MapLoader.PathFinding.GetGrid().GetGridObject(Position.x, Position.y + MapLoader.CurrentMapHeight).isWalkable = true;
                    MapLoader.PathFinding.GetGrid().GetGridObject(targetPosition.x, targetPosition.y + MapLoader.CurrentMapHeight).isWalkable = false;
                    Position = targetPosition;
                }
            }
        }

        /// <summary>
        ///     Invoked whenever another actor attempts to walk on the same position
        ///     this actor is placed.
        /// </summary>
        /// <param name="anotherActor"></param>
        /// <returns>true if actor can walk on this position, false if not</returns>
        public virtual bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
            {
                UserInterface.Singleton.SetText("Press E to pick up", UserInterface.TextPosition.BottomRight);
                anotherActor.ItemUnder = this;
            }
            // All actors are passable by default
            return true;
        }
        
        /// <summary>
        ///     Invoked every animation frame, can be used for movement, character logic, etc
        /// </summary>
        /// <param name="deltaTime">Time (in seconds) since the last animation frame</param>
        protected virtual void OnUpdate(float deltaTime)
        {
        }


        public virtual void ApplyDamage(int damage)
        {
            //this.Health -= damage;
            //if (this.Health <= 0)
            //{
            //    // Die
            //    //Character.OnDeath();
            //    var cams = GameObject.FindObjectsOfType(typeof(Camera));
            //    foreach (Camera cam in cams)
            //    {
            //        if (cam.name == "BattleCamera")
            //        {
            //            cam.enabled = false;
            //        }
            //    }
            //    ActorManager.Singleton.DestroyActor(this);
            //}
        }

        /// <summary>
        ///     Can this actor be detected with ActorManager.GetActorAt()? Should be false for purely cosmetic actors
        /// </summary>
        public virtual bool Detectable => true;

        /// <summary>
        ///     Z position of this Actor (0 by default)
        /// </summary>
        public virtual int Z => 0;

        /// <summary>
        ///     Id of the default sprite of this actor type
        /// </summary>
        public abstract int DefaultSpriteId { get; }

        /// <summary>
        ///     Default name assigned to this actor type
        /// </summary>
        public abstract string DefaultName { get; }

        public abstract char DefaultChar { get; }

        public virtual int Health { get; set; } = 0;

        public virtual int MaxHealth { get; set;}

        public virtual bool IsWalkable => false;
        public List<Actor> Inventory = new List<Actor>();
        public Actor ItemUnder;

        public virtual int Damage { get; set; } = 0;

        public AudioSource AttackSound;
        public AudioSource DeathSound;
        public virtual string AttackSoundFileName { get; set; }
        public virtual string DeathSoundFileName { get; set; }
    }
}