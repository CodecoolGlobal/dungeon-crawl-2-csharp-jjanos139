namespace DungeonCrawl.Actors.Static
{
    public class Battleaxe : Actor
    {
        public override int DefaultSpriteId => 376;
        public override string DefaultName => "Battleaxe";
        public override int Z => -1;


        public override bool Detectable => false;
    }
}