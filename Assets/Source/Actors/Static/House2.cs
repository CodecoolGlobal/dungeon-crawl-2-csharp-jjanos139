using UnityEngine.Experimental.Rendering.Universal;

namespace DungeonCrawl.Actors.Static
{
    public class House2 : Actor
    {
        private void Awake()
        {
            base.Awake();
            gameObject.AddComponent<ShadowCaster2D>();
        }
        public override int DefaultSpriteId => 967;
        public override string DefaultName => "House2";
        public override int Z => -1;
        public override char DefaultChar => 'Ó';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}