namespace DungeonCrawl.Actors.Static
{
    public class BrokenIronBars : Actor
    {
        public override int DefaultSpriteId => 149;
        public override string DefaultName => "BrokenIronBars";
        public override int Z => -1;


        public override bool Detectable => false;
    }
}