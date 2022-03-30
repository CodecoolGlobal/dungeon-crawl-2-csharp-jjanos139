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

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor.DefaultName == "Player")
            {
                anotherActor.Inventory.Add(this);
                ActorManager.Singleton.DestroyActor(this);
            }
            return true;
    }

        public override bool Detectable => true;
    }
}