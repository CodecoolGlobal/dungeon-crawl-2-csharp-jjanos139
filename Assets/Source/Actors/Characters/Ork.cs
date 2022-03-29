using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ork : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Looks like meat is back on the menu boys.");
        }

        public override int DefaultSpriteId => 124;
        public override string DefaultName => "Ork";
    }
}