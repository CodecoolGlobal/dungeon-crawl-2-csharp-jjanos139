namespace DungeonCrawl.Actors.Static
{
    public class Bush2 : Actor
    {
        public override int DefaultSpriteId => 101;
        public override string DefaultName => "Bush2";
        public override char DefaultChar => '×';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}