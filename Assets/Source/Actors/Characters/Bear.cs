using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Bear : Character
    {
        private AudioSource _bearSound;
        private AudioSource _bearDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _bearSound = Instantiate(Resources.Load<AudioSource>("BearSound"));
            _bearSound.transform.parent = transform;
            _bearDeathSound = Instantiate(Resources.Load<AudioSource>("BearDeathSound"));
            _bearDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _bearSound.Play();
            return true;
        }

        protected override void OnDeath()
        {
            _bearDeathSound.Play();
            Debug.Log("It's because I'm smarter than the average bear.");
        }

        public override int DefaultSpriteId => 413;
        public override string DefaultName => "Bear";

        public override bool Detectable => true;
    }
}