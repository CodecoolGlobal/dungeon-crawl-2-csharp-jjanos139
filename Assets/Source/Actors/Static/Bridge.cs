namespace DungeonCrawl.Actors.Static
{
    public class Bridge : Actor
    {
        public override int DefaultSpriteId => 197;
        public override string DefaultName => "Bridge";

        public override bool Detectable => false;

        public override char DefaultChar => '-';
    }
}