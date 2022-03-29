using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Spider : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Remember, with great power comes great responsibility...");
        }

        public override int DefaultSpriteId => 267;
        public override string DefaultName => "Spider";
    }
}