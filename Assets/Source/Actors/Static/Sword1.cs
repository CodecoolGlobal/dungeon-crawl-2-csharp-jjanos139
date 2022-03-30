using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Sword1 : Actor
    {
        public override int DefaultSpriteId => 369;
        public override string DefaultName => "Sword1";
        public override int Z => -1;
        //public void ScaleSet()
        //{
        //    gameObject.transform.localScale = new Vector3(1, -1, 1);
        //}

        public void OnTriggerExit2D(Collider2D collider2D)
        {
            UserInterface.Singleton.SetText(null, UserInterface.TextPosition.BottomRight);
            ActorManager.Singleton.GetPlayer().ItemUnder = null;
        }

        public override bool Detectable => true;
    }
}