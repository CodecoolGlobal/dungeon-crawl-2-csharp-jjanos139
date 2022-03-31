using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Potion : Actor
    {
        private AudioSource _itemPickUp;

        private void Awake()
        {
            base.Awake();
            InstantiateAudio();
        }

        private void InstantiateAudio()
        {
            _itemPickUp = Instantiate(Resources.Load<AudioSource>("ItemPickUp"));
            _itemPickUp.transform.parent = transform;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
            {
                UserInterface.Singleton.SetText("Press E to pick up", UserInterface.TextPosition.BottomRight);
                anotherActor.ItemUnder = this;
            }
            else if (anotherActor is Player)
                _itemPickUp.Play();
            return true;
        }

        public override int DefaultSpriteId => 569;
        public override string DefaultName => "Potion";

        public override bool Detectable => true;
        public override int Z => -1;
        public void OnTriggerExit2D(Collider2D collider2D)
        {
            UserInterface.Singleton.SetText(null, UserInterface.TextPosition.BottomRight);
            ActorManager.Singleton.GetPlayer().ItemUnder = null;
        }
        public override char DefaultChar => 'P';
    }
}