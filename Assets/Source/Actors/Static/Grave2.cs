namespace DungeonCrawl.Actors.Static
{
    public class Grave2 : Actor
    {
        public override int DefaultSpriteId => 671;
        public override string DefaultName => "Grave2";
        public override int Z => -1;


        public override bool OnCollision(Actor anotherActor)
        {
            if (DefaultName == "Soul")
            {
                return true;
            }
            return false;
        }

        public override char DefaultChar => '(';
    }
}