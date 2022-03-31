namespace DungeonCrawl.Actors.Static
{
    public class Mace : Actor
    {
        public override int DefaultSpriteId => 372;
        public override string DefaultName => "Mace";
        public override int Z => -1;

        public override char DefaultChar => '¤';

        public override bool Detectable => false;
    }
}