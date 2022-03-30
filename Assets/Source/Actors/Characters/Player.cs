using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        private FieldOfView _fieldOfView;

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();

            SetSprite(DefaultSpriteId);

            CameraController.Singleton.Camera.transform.parent = this.transform;
            CameraController.Singleton.Position = (0, 0);

            _fieldOfView = Instantiate(Resources.Load<FieldOfView>("FieldOfView"));
            _fieldOfView.transform.parent = this.transform;
            _fieldOfView.SetOrigin(transform.position);

            //SpriteMask spriteMask = Instantiate(Resources.Load<SpriteMask>("Sprite Mask"));
            //spriteMask.transform.parent = this.transform;
        }

        protected override void OnUpdate(float deltaTime)
        {
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

            _fieldOfView.SetOrigin(transform.position);
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}
