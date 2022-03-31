namespace DungeonCrawl.Actors.Static
{
    public class Gate : Actor
    {
        public override int DefaultSpriteId => 548;
        public override string DefaultName => "Gate";
        public override bool Detectable => false;
        //public override bool OnCollision(Actor anotherActor)
        //{
        //    return false;
        //}
    }
}