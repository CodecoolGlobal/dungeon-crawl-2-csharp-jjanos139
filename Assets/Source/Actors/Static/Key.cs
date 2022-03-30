namespace DungeonCrawl.Actors.Static
{
    public class Key : Actor
    {
        public override int DefaultSpriteId => 559;
        public override string DefaultName => "Key";
        public override int Z => -1;


        public override bool Detectable => false;

        public override char DefaultChar => 'K';
    }
}