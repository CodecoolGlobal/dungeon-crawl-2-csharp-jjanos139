namespace DungeonCrawl.Actors.Static
{
    public class IronBars : Actor
    {
        public override int DefaultSpriteId => 148;
        public override string DefaultName => "IronBars";
        public override int Z => -1;


        public override bool OnCollision(Actor anotherActor)
        {
            if (DefaultName == "Soul")
            {
                return true;
            }
            return false;
        }
    }
}