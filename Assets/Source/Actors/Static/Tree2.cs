﻿using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Tree2 : Actor
    {
        public override int DefaultSpriteId => 48;
        public override string DefaultName => "Tree2";
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                return false;
            return true;
        }

        public override char DefaultChar => 'F';
    }
}