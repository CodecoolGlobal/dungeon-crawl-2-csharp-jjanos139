using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ogre : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("ME SMASH!");
        }

        public override int DefaultSpriteId => 317;
        public override string DefaultName => "Ogre";

        public override char DefaultChar => 'r';
    }
}