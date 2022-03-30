namespace DungeonCrawl.Actors.Static
{
    public class Explosive : Actor
    {
        public override int DefaultSpriteId => 476;
        public override string DefaultName => "Explosive";
        public override int Z => -1;

        public override bool Detectable => false;

        public override char DefaultChar => 'e';
    }
}