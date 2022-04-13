using UnityEngine.Experimental.Rendering.Universal;

namespace DungeonCrawl.Actors.Static
{
    public class House : Actor
    {
        private void Awake()
        {
            base.Awake();
            gameObject.AddComponent<ShadowCaster2D>();
        }
        public override int DefaultSpriteId => 966;
        public override string DefaultName => "House";
        public override int Z => -1;
        public override char DefaultChar => ')';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}