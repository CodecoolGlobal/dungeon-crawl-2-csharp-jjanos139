using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Snake : Character
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
            Debug.Log("Trust in me...");
        }

        public override int DefaultSpriteId => 411;
        public override string DefaultName => "Snake";
        public override int Health
        {
            get;
            set;
        } = 100;

        public override int MaxHealth => 100;

        public override int Damage => 10;
        public override char DefaultChar => 'S';
    }
}