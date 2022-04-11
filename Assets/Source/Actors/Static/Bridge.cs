using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Bridge : Actor
    {
        private AudioSource _bridgeStep;
        
        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _bridgeStep = Instantiate(Resources.Load<AudioSource>("BridgeStep"));
            _bridgeStep.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
                _bridgeStep.Play();
            return true;
        }

        public override bool IsWalkable => true;
        public override int DefaultSpriteId => 197;
        public override string DefaultName => "Bridge";

        public override bool Detectable => false;

        public override char DefaultChar => '-';
    }
}