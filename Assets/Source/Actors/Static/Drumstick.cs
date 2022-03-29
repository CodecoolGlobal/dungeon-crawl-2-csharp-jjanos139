namespace DungeonCrawl.Actors.Static
{
    public class Drumstick : Actor
    {
        public override int DefaultSpriteId => 800;
        public override string DefaultName => "Drumstick";

        public override bool Detectable => false;
    }
}