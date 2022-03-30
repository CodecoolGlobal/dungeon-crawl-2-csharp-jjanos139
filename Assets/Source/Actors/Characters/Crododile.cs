using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Crocodile : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Get on the right side of the road you pelican!");
        }

        public override int DefaultSpriteId => 412;
        public override string DefaultName => "Crocodile";

        public override char DefaultChar => 'c';
    }
}