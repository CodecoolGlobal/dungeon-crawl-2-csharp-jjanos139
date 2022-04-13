using UnityEngine.Experimental.Rendering.Universal;

namespace DungeonCrawl.Actors.Static
{
    public class Tent : Actor
    {
        private void Awake()
        {
            base.Awake();
            gameObject.AddComponent<ShadowCaster2D>();
        }
        public override int DefaultSpriteId => 966;
        public override string DefaultName => "Tent";
        public override char DefaultChar => 'N';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}