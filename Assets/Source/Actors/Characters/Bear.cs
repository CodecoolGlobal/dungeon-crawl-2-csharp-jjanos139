using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Bear : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("It's because I'm smarter than the average bear.");
        }

        public override int DefaultSpriteId => 413;
        public override string DefaultName => "Bear";

        public override char DefaultChar => 'B';
    }
}