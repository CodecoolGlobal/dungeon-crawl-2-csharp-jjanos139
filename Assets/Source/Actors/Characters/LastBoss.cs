using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class LastBoss : Character
    {
        BattleSystem battleSystem = new BattleSystem();
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                battleSystem.SetupBattle(this.DefaultSpriteId, this, anotherActor);
                return true;
            }
            return false;
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
            Debug.Log("I will return!");
        }

        public override int DefaultSpriteId => 455;
        public override string DefaultName => "LastBoss";

        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;
        public override char DefaultChar => '§';
    }
}