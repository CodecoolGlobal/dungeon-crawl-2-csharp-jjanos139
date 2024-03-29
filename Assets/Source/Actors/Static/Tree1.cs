﻿using UnityEngine.Experimental.Rendering.Universal;

namespace DungeonCrawl.Actors.Static
{
    public class Tree1 : Actor
    {
        private void Awake()
        {
            base.Awake();
            gameObject.AddComponent<ShadowCaster2D>();
        }
        public override int DefaultSpriteId => 49;
        public override string DefaultName => "Tree1";
        public override int Z => -1;
        public override char DefaultChar => 'f';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}