using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Wizard : Character
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
            Debug.Log("Run, you fool.");
        }

        public override string AttackSoundFileName => "WizardSound";
        public override string DeathSoundFileName => "DeathSound1";
        public override int DefaultSpriteId => 457;
        public override string DefaultName => "Wizard";
        public override int Health
        {
            get;
            set;
        } = 200;
        public override int MaxHealth => 200;
        public override int Damage => 10;
        public override char DefaultChar => 'v';
    }
}