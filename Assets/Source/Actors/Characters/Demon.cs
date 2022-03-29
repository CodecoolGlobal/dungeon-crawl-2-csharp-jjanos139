using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Demon : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Burn!!!");
        }

        public override int DefaultSpriteId => 122;
        public override string DefaultName => "Demon";
    }
}