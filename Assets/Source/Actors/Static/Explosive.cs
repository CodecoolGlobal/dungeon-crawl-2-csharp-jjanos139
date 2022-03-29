namespace DungeonCrawl.Actors.Static
{
    public class Explosive : Actor
    {
        public override int DefaultSpriteId => 476;
        public override string DefaultName => "Explosive";

        public override bool Detectable => false;
    }
}