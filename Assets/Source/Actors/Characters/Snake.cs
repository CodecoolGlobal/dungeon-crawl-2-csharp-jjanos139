using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Snake : Character
    {
        protected override void OnUpdate(float deltaTime)
        {
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                battleSystem.HandleActionSelection();
            }
        }

        protected override void OnDeath()
        {
            DeathSound.Play();
            Debug.Log("Trust in me...");
        }

        public override string AttackSoundFileName => "Sounds/SnakeSound";
        public override string DeathSoundFileName => "Sounds/SnakeDeathSound";
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
        public override bool Detectable => true;
    }
}