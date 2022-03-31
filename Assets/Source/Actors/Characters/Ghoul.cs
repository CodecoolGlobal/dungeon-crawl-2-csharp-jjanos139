using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghoul : Character
    {
        private AudioSource _ghoulSound;
        private AudioSource _ghoulDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _ghoulSound = Instantiate(Resources.Load<AudioSource>("GhoulSound"));
            _ghoulSound.transform.parent = transform;
            _ghoulDeathSound = Instantiate(Resources.Load<AudioSource>("GhoulDeathSound"));
            _ghoulDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _ghoulSound.Play();
            return true;
        }
        protected override void OnUpdate(float deltaTime)
        {
            _turnCounter += deltaTime;
            if (_turnCounter >= 1)
            {
                _turnCounter = 0;
                (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                CheckIfAggro(playerCoords, 2, 5);

                if (_isAggro)
                {
                    TryMove(GetMoveDirection(playerCoords));
                }
                else if (!_isAggro)
                {
                    Direction direction = GetRandomDirection();
                    TryMove(direction);
                }
            }
        }

        private float _turnCounter;


        protected override void OnDeath()
        {
            _ghoulDeathSound.Play();
            Debug.Log("Zoinks! G-G-G-G-Ghost");
        }

        public override int DefaultSpriteId => 315;
        public override string DefaultName => "Ghoul";
    }
}