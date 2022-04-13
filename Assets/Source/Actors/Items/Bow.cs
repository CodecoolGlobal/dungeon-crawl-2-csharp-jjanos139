namespace Assets.Source.Actors.Items
{
    public class Bow : Item
    {
        public override int DefaultSpriteId => 325;
        public override string DefaultName => "Bow";
        public override char DefaultChar => 'o';
        public override int Damage => 10;
    }
}