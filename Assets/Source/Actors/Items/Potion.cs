namespace Assets.Source.Actors.Items
{
    public class Potion : Item
    {
        public override int DefaultSpriteId => 569;
        public override string DefaultName => "Potion";
        public override char DefaultChar => 'P';
        public override int Damage => -50;
    }
}