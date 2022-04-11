namespace DungeonCrawl.Actors.Static
{
    public class Gate2 : Actor
    {
        public override int DefaultSpriteId => 437;
        public override string DefaultName => "Gate2";
        public override bool Detectable => false;
        public override bool IsWalkable => true;

        public override char DefaultChar => 'k';

        //public override bool OnCollision(Actor anotherActor)
        //{
        //    return false;
        //}

    }
}