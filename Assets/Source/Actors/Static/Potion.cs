namespace DungeonCrawl.Actors.Static
{
    public class Potion : Actor
    {
        public override int DefaultSpriteId => 569;
        public override string DefaultName => "Potion";

        public override bool Detectable => false;
        public override int Z => -1;

        public override char DefaultChar => 'P';
    }
}