using Assets.Source.Actors.Static;

namespace DungeonCrawl.Actors.Static
{
    public class Bridge : Traversable
    {       
        public override string AttackSoundFileName => "Sounds/BridgeStep";
        public override bool IsWalkable => true;
        public override int DefaultSpriteId => 197;
        public override string DefaultName => "Bridge";
        public override bool Detectable => true;
        public override char DefaultChar => '-';
    }
}