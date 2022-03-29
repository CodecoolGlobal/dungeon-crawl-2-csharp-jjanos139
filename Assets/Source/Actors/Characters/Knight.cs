using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Knight : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("How...?");
        }

        public override int DefaultSpriteId => 30;
        public override string DefaultName => "Knight";
    }
}