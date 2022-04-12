using DungeonCrawl.Core;
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

        public override string AttackSoundFileName => "LastBossSound";
        public override string DeathSoundFileName => "Victory";
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