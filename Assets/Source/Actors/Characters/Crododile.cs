using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Crocodile : Character
    {
        BattleSystem battleSystem = new BattleSystem();
        public override bool OnCollision(Actor anotherActor)
        {

            battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
            return true;
        }


        protected override void OnUpdate(float deltaTime)
        {
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                battleSystem.HandleActionSelection();
            }
        }

        protected override void OnDeath()
        {
            Debug.Log("Get on the right side of the road you pelican!");
        }

        public override int DefaultSpriteId => 412;
        public override string DefaultName => "Crocodile";
        public override int Health
        {
            get;
            set;
        } = 40;

        public override int MaxHealth => 40;

        public override int Damage => 10;

        public override char DefaultChar => 'c';
    }
}