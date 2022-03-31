namespace DungeonCrawl.Actors.Static
{
    public class Helm : Actor
    {
        public override int DefaultSpriteId => 35;
        public override string DefaultName => "Helm";
        public override int Z => -1;


        public override bool Detectable => false;
    }
}