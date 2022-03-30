﻿using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghoul : Character
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Debug.Log("Zoinks! G-G-G-G-Ghost");
        }

        public override int DefaultSpriteId => 313;
        public override string DefaultName => "Ghoul";

        public override char DefaultChar => 'g';
    }
}