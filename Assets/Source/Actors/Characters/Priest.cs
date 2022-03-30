using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Priest : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Finally. Descension.");
        }

        public override int DefaultSpriteId => 78;
        public override string DefaultName => "Priest";

        public override char DefaultChar => '%';
    }
}