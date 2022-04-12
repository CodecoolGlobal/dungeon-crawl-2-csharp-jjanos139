using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Scorpion : Character
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
            Debug.Log("Take me to the magic of the moment\nOn a glory night");
        }

        public override string AttackSoundFileName => "ScorpionSound";
        public override string DeathSoundFileName => "ScorpionDeathSound";
        public override int DefaultSpriteId => 263;
        public override string DefaultName => "Scorpion";
        public override int Health
        {
            get;
            set;
        } = 100;
        public override int MaxHealth => 100;
        public override int Damage => 10;
        public override char DefaultChar => 'x';
    }
}