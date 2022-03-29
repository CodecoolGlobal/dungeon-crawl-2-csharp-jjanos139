namespace DungeonCrawl.Actors.Static
{
    public class Amulet : Actor
    {
        public override int DefaultSpriteId => 428;
        public override string DefaultName => "Amulet";
        public override int Z => -1;


        public override bool Detectable => false;
    }
}