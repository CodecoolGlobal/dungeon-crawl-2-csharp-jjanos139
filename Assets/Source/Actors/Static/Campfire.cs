using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace DungeonCrawl.Actors.Static
{
    public class Campfire : Actor
    {
        private Light2D _light2D;

        public void Awake()
        {
            base.Awake();
            _light2D = Instantiate(Resources.Load<Light2D>("Shaders/CampfireLight"));
            _light2D.transform.parent = transform;
        }
        public override int DefaultSpriteId => 493;
        public override string DefaultName => "Campfire";
        public override char DefaultChar => 't';
        
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}