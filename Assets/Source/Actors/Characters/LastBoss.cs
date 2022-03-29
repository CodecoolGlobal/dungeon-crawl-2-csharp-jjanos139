using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class LastBoss : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("I will return!");
        }

        public override int DefaultSpriteId => 455;
        public override string DefaultName => "LastBoss";
    }
}