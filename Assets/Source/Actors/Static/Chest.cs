namespace DungeonCrawl.Actors.Static
{
    public class Chest : Actor
    {
        public override int DefaultSpriteId => 579;
        public override string DefaultName => "Chest";
        public override int Z => -1;

        public override char DefaultChar => '$';

        public override bool Detectable => false;
    }
}