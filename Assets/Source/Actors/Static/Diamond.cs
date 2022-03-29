namespace DungeonCrawl.Actors.Static
{
    public class Diamond : Actor
    {
        public override int DefaultSpriteId => 214;
        public override string DefaultName => "Diamond";
        public override int Z => -1;


        public override bool Detectable => false;
    }
}