namespace DungeonCrawl.Actors.Static
{
    public class Danger : Actor
    {
        public override int DefaultSpriteId => 1047;
        public override string DefaultName => "Danger";

        public override bool Detectable => false;
    }
}