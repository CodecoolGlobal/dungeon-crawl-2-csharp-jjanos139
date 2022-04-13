using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class LastBoss : Character
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
            Debug.Log("I will return!");
        }

        public override string AttackSoundFileName => "Sounds/LastBossSound";
        public override string DeathSoundFileName => "Sounds/Victory";
        public override int DefaultSpriteId => 455;
        public override string DefaultName => "LastBoss";
        public override int Health
        {
            get;
            set;
        } = 450;
        public override int MaxHealth => 450;
        public override int Damage => 40;
        public override char DefaultChar => '§';
    }
}