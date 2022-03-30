namespace DungeonCrawl.Actors.Static
{
    public class Shield1 : Actor
    {
        public override int DefaultSpriteId => 135;
        public override string DefaultName => "Shield1";
        public override int Z => -1;


        public override bool Detectable => false;

        public override char DefaultChar => '1';
    }
}