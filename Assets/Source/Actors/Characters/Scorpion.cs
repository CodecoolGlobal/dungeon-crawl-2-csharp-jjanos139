using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Scorpion : Character
    {
        private AudioSource _scorpionSound;
        private AudioSource _scorpionDeathSound;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _scorpionSound = Instantiate(Resources.Load<AudioSource>("ScorpionSound"));
            _scorpionSound.transform.parent = transform;
            _scorpionDeathSound = Instantiate(Resources.Load<AudioSource>("ScorpionDeathSound"));
            _scorpionDeathSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _scorpionSound.Play();
            return true;
        }

        protected override void OnDeath()
        {
            _scorpionDeathSound.Play();
            Debug.Log("Take me to the magic of the moment\nOn a glory night");
        }

        public override int DefaultSpriteId => 263;
        public override string DefaultName => "Scorpion";
        public override bool Detectable => true;
    }
}