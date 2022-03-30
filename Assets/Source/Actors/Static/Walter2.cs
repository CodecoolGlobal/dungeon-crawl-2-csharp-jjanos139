namespace DungeonCrawl.Actors.Static
{
    public class Walter2 : Actor
    {
        public override int DefaultSpriteId => 1054;
        public override string DefaultName => "Walter2";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
                return false;
            return true;
        }
        public override char DefaultChar => 'E';
    }
}