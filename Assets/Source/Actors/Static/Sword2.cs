namespace DungeonCrawl.Actors.Static
{
    public class Sword2 : Actor
    {
        public override int DefaultSpriteId => 416;
        public override string DefaultName => "Sword2";
        public override int Z => -1;

        public override bool Detectable => false;
    }
}