namespace DungeonCrawl.Actors.Static
{
    public class Armor : Actor
    {
        public override int DefaultSpriteId => 84;
        public override string DefaultName => "Armor";
        public override int Z => -1;


        public override bool Detectable => false;
    }
}