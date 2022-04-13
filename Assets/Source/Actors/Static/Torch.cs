using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace DungeonCrawl.Actors.Static
{
    public class Torch : Actor
    {
        private Light2D _light2D;

        public void Awake()
        {
            base.Awake();
            _light2D = Instantiate(Resources.Load<Light2D>("Shaders/TorchLight"));
            _light2D.transform.parent = transform;
        }
        public override int DefaultSpriteId => 722;
        public override string DefaultName => "Torch";
        public override int Z => -1;
        public override bool Detectable => true;
        public override char DefaultChar => 'ő';

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}