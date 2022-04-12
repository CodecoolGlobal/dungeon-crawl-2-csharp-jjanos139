using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Crocodile : Character
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
            Debug.Log("Get on the right side of the road you pelican!");
        }

        public override string AttackSoundFileName => "CrocSound";
        public override string DeathSoundFileName => "CrocDeathSound";
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