using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Tree3 : Actor
    {
        public override int DefaultSpriteId => 98;
        public override string DefaultName => "Tree3";
        public override int Z => -1;
        public override char DefaultChar => 'u';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}