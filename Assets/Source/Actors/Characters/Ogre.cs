using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ogre : Character
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
            Debug.Log("ME SMASH!");
        }

        public override string AttackSoundFileName => "OgreSound";
        public override string DeathSoundFileName => "OgreDeathSound";
        public override int DefaultSpriteId => 317;
        public override string DefaultName => "Ogre";
        public override int Health
        {
            get;
            set;
        } = 100;
        public override int MaxHealth => 100;
        public override int Damage => 10;
        public override char DefaultChar => 'r';
    }
}