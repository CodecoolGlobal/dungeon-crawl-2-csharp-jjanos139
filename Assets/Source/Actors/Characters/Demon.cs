using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Demon : Character
    {
        private AudioSource _demonSound;
        private AudioSource _demonDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _demonSound = Instantiate(Resources.Load<AudioSource>("DemonSound"));
            _demonSound.transform.parent = transform;
            _demonDeathSound = Instantiate(Resources.Load<AudioSource>("DemonDeathSound"));
            _demonDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player) 
                _demonSound.Play();
            return true;
        }

        protected override void OnDeath()
        {
            _demonDeathSound.Play();
            Debug.Log("Burn!!!");
        }

        public override int DefaultSpriteId => 122;
        public override string DefaultName => "Demon";
    }
}