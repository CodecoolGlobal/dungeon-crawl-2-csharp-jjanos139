using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace Assets.Source.Actors.Static
{
    public abstract class Traversable : Actor
    {
        public void Awake()
        {
            base.Awake();
            InstantiateAudio(AttackSoundFileName);
        }

        protected override void InstantiateAudio(string stepSound, string _ = "")
        {
            AttackSound = Instantiate(Resources.Load<AudioSource>(stepSound));
            AttackSound.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                AttackSound.Play();
            return true;
        }
    }
}
