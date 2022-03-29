namespace DungeonCrawl.Actors.Static
{
    public class Table : Actor
    {
        public override int DefaultSpriteId => 234;
        public override string DefaultName => "Table";
        public override int Z => -1;


        public override bool Detectable => false;
    }
}