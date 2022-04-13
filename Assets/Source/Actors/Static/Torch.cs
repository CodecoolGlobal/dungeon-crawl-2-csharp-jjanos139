using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Torch : Actor
    {
        public override int DefaultSpriteId => 722;
        public override string DefaultName => "Torch";
        public override int Z => -1;
        public override bool Detectable => true;
        public override char DefaultChar => 'ő';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}