using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class BrokenIronBars : Actor
    {
        public override int DefaultSpriteId => 149;
        public override string DefaultName => "BrokenIronBars";
        public override int Z => -1;
        public override bool IsWalkable => true;
        public override bool Detectable => false;
        public override char DefaultChar => '0';
    }
}