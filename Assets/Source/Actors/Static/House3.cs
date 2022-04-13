using UnityEngine.Experimental.Rendering.Universal;

namespace DungeonCrawl.Actors.Static
{
    public class House3 : Actor
    {
        private void Awake()
        {
            base.Awake();
            gameObject.AddComponent<ShadowCaster2D>();
        }
        public override int DefaultSpriteId => 1015;
        public override string DefaultName => "House3";
        public override int Z => -1;
        public override char DefaultChar => 'Ä';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}