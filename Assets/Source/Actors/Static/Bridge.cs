using Assets.Source.Actors.Static;
using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Bridge : Traversable
    {       
        public override string AttackSoundFileName => "BridgeStep";
        public override bool IsWalkable => true;
        public override int DefaultSpriteId => 197;
        public override string DefaultName => "Bridge";
        public override bool Detectable => false;
        public override char DefaultChar => '-';
    }
}