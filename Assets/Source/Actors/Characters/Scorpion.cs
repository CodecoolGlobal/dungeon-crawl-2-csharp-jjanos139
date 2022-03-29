using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Scorpion : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Take me to the magic of the moment\nOn a glory night");
        }

        public override int DefaultSpriteId => 263;
        public override string DefaultName => "Scorpion";
    }
}