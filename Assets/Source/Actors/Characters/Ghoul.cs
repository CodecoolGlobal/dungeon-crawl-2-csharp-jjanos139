using UnityEngine;

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


        protected override void OnDeath()
        {
            _ghoulDeathSound.Play();
            Debug.Log("Zoinks! G-G-G-G-Ghost");
        }

        public override int DefaultSpriteId => 315;
        public override string DefaultName => "Ghoul";
    }
}