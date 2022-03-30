using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Bush : Actor
    {
        public override int DefaultSpriteId => 96;
        public override string DefaultName => "Bush";
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
                return false;
            return true;
        }

        public override char DefaultChar => 'z';
    }
}