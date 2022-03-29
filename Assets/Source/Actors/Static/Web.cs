namespace DungeonCrawl.Actors.Static
{
    public class Web : Actor
    {
        public override int DefaultSpriteId => 721;
        public override string DefaultName => "Web";
        public override int Z => -1;


        public override bool Detectable => false;
    }
}