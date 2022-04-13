using UnityEngine;
using Assets.Source.Actors.Static;

namespace DungeonCrawl.Actors.Static
{
    public class Floor : Traversable
    {
        protected override void InstantiateAudio(string _, string __)
        {
            _footStepCave1 = Instantiate(Resources.Load<AudioSource>("Sounds/FootStepCave1"));
            _footStepCave2 = Instantiate(Resources.Load<AudioSource>("Sounds/FootStepCave2"));
            _footStepCave3 = Instantiate(Resources.Load<AudioSource>("Sounds/FootStepCave3"));
            _footStepCave1.transform.parent = transform;
            _footStepCave2.transform.parent = transform;
            _footStepCave3.transform.parent = transform;
        }

        private void PlayRandomFootStepCaveSound()
        {
            int soundCase = Utilities.GetRandomIntBetween(1, 4);

            switch (soundCase)
            {
                case 1: _footStepCave1.Play(); break;
                case 2: _footStepCave2.Play(); break;
                case 3: _footStepCave3.Play(); break;
            }
        }
        public void OnTriggerEnter2D(Collider2D collider2D)
        {
            PlayRandomFootStepCaveSound();
        }

        private AudioSource _footStepCave1;
        private AudioSource _footStepCave2;
        private AudioSource _footStepCave3;
        public override int DefaultSpriteId => 106;
        public override string DefaultName => "Floor";
        public override bool IsWalkable => true;
        public override bool Detectable => false;
        public override char DefaultChar => '.';
    }
}
