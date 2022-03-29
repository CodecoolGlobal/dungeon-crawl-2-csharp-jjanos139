﻿namespace DungeonCrawl.Actors.Static
{
    public class Water2 : Actor
    {
        public override int DefaultSpriteId => 203;
        public override string DefaultName => "Water2";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
                return false;
            return true;
        }
    }
}