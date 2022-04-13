using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Tree1 : Actor
    {
        public override int DefaultSpriteId => 49;
        public override string DefaultName => "Tree1";
        public override int Z => -1;
        public override char DefaultChar => 'f';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}