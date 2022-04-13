namespace Assets.Source.Actors.Items
{
    public class Heart : Item
    {
        public override int DefaultSpriteId => 521;
        public override string DefaultName => "Heart";
        public override char DefaultChar => 'H';
        public override int Health => 50;
    }
}