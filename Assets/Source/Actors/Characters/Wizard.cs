using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Wizard : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Run, you fool.");
        }

        public override int DefaultSpriteId => 457;
        public override string DefaultName => "Wizard";

        public override char DefaultChar => 'v';
    }
}