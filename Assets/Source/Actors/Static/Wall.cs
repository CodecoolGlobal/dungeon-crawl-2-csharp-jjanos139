using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Wall : Actor
    {
        public override int DefaultSpriteId => 825;
        public override string DefaultName => "Wall";
        public override bool OnCollision(Actor anotherActor)
        {
            //if (anotherActor.DefaultName == "Player" || anotherActor.DefaultName == "Player")
            //    return false;
            return false;
        }

        public override char DefaultChar => '#';
    }
}
