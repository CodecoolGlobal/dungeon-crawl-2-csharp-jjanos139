using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghoul : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Zoinks! G-G-G-G-Ghost");
        }

        public override int DefaultSpriteId => 315;
        public override string DefaultName => "Ghoul";
    }
}