namespace DungeonCrawl.Actors.Static
{
    public class Cactus : Actor
    {
        public override int DefaultSpriteId => 53;
        public override string DefaultName => "Cactus";
        public override int Z => -1;
        public override bool Detectable => false;
        public override char DefaultChar => 'C';
    }
}