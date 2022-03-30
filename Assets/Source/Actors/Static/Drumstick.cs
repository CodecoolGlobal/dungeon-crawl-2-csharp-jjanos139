namespace DungeonCrawl.Actors.Static
{
    public class Drumstick : Actor
    {
        public override int DefaultSpriteId => 800;
        public override string DefaultName => "Drumstick";
        public override int Z => -1;

        public override bool Detectable => false;

        public override char DefaultChar => 'd';
    }
}