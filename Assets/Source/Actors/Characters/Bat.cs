using DungeonCrawl.Core;
using UnityEngine;
using DungeonCrawl;

namespace DungeonCrawl.Actors.Characters
{
    public class Bat : Character
    {
        protected override void OnUpdate(float deltaTime)
        {
            if (battleSystem.state == BattleStatus.PlayerMove)
            {
                battleSystem.HandleActionSelection();
            }

            if (!ActorManager.Singleton.IsCombat)
            {
                _turnCounter += deltaTime;
                if (_turnCounter >= 0.7)
                {
                    _turnCounter = 0;
                    (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                    Direction direction = Utilities.GetRandomDirection();
                    TryMove(direction);
                }
            }
        }

        protected override void OnDeath()
        {
            DeathSound.Play();
            Debug.Log("I won’t kill you, but I don’t have to save you.");
        }

        public override string AttackSoundFileName => "BatSound";
        public override string DeathSoundFileName => "BatDeathSound";
        private float _turnCounter;
        public override int DefaultSpriteId => 409;
        public override string DefaultName => "Bat";
        public override int Health
        {
            get;
            set;
        } = 100;
        public override int MaxHealth => 100;
        public override int Damage => 10;
        public override char DefaultChar => 'b';
    }
}