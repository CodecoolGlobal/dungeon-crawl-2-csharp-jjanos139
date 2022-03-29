namespace DungeonCrawl.Actors.Static
{
    public class Heart : Actor
    {
        public override int DefaultSpriteId => 521;
        public override string DefaultName => "Heart";
        public override int Z => -1;


        public override bool Detectable => false;
    }
}