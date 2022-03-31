using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Spider : Character
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
            Debug.Log("Remember, with great power comes great responsibility...");
        }

        public override int DefaultSpriteId => 267;
        public override string DefaultName => "Spider";
        public override int Health
        {
            get;
            set;
        } = 10;

        public override int MaxHealth => 10;

        public override int Damage => 10;

        public override char DefaultChar => 'X';
    }
}