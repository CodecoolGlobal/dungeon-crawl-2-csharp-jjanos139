namespace DungeonCrawl.Actors.Static
{
    public class Trapdoor : Actor
    {
        public override int DefaultSpriteId => 731;
        public override string DefaultName => "Trapdoor";
        public override int Z => -1;

        public override bool Detectable => false;
    }
}