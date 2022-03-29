using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Soul : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Woosh.");
        }

        public override int DefaultSpriteId => 314;
        public override string DefaultName => "Soul";
    }
}