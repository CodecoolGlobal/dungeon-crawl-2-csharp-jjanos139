using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Bat : Character
    {
        private AudioSource _batSound;
        private AudioSource _batDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _batSound = Instantiate(Resources.Load<AudioSource>("BatSound"));
            _batSound.transform.parent = transform;
            _batDeathSound = Instantiate(Resources.Load<AudioSource>("BatDeathSound"));
            _batDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _batSound.Play();
            return true;
        }

        protected override void OnDeath()
        {
            _batDeathSound.Play();
            Debug.Log("I won’t kill you, but I don’t have to save you.");
        }

        public override int DefaultSpriteId => 409;
        public override string DefaultName => "Bat";

        public override char DefaultChar => 'b';
        public override bool Detectable => true;
    }
}