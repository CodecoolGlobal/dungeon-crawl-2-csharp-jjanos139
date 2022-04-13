namespace Assets.Source.Actors.Items
{
    public class Amulet : Item
    {
        public override int DefaultSpriteId => 428;
        public override string DefaultName => "Amulet";
        public override char DefaultChar => 'a';
        public override int Health => 70;
        public override int Damage => 20;
    }
}