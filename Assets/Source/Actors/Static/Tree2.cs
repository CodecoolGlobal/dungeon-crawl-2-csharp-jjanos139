using UnityEngine.Experimental.Rendering.Universal;

namespace DungeonCrawl.Actors.Static
{
    public class Tree2 : Actor
    {
        private void Awake()
        {
            base.Awake();
            gameObject.AddComponent<ShadowCaster2D>();
        }
        public override int DefaultSpriteId => 48;
        public override string DefaultName => "Tree2";
        public override int Z => -1;
        public override char DefaultChar => 'F';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}