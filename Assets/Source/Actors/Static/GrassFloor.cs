namespace DungeonCrawl.Actors.Static
{
    public class GrassFloor : Actor
    {
        public override int DefaultSpriteId => 0;
        public override string DefaultName => "GrassFloor";

        public override bool Detectable => false;
    }
}