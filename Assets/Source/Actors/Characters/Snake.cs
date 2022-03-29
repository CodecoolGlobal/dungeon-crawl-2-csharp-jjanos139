using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Snake : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Trust in me...");
        }

        public override int DefaultSpriteId => 412;
        public override string DefaultName => "Snake";
    }
}