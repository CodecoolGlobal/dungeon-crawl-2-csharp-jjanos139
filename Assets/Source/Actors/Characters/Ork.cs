using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ork : Character
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
            Debug.Log("Looks like meat is back on the menu boys.");
        }

        public override string AttackSoundFileName => "Sounds/OrkSound";
        public override string DeathSoundFileName => "Sounds/OrkDeathSound";
        public override int DefaultSpriteId => 124;
        public override string DefaultName => "Ork";
        public override int Health
        {
            get;
            set;
        } = 100;
        public override int MaxHealth => 100;
        public override int Damage => 10;
        public override char DefaultChar => 'O';
    }
}