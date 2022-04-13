using DungeonCrawl.Core;
using UnityEngine;
using static DungeonCrawl.Utilities;

namespace DungeonCrawl.Actors.Characters
{
    public class Priest : Character
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
                if (_turnCounter >= 1)
                {
                    _turnCounter = 0;
                    (int x, int y) playerCoords = ActorManager.Singleton.GetPlayer().Position;
                    Direction direction = GetRandomDirection();
                    TryMove(direction);
                }

                if (battleSystem.state == BattleStatus.PlayerMove)
                {
                    battleSystem.HandleActionSelection();
                }
            }
        }

        protected override void OnDeath()
        {
            DeathSound.Play();
            Debug.Log("Finally. Descension.");
        }

        private float _turnCounter;
        public override string AttackSoundFileName => "Sounds/PriestSound";
        public override string DeathSoundFileName => "Sounds/DeathSound2";
        public override int DefaultSpriteId => 78;
        public override string DefaultName => "Priest";
        public override int Health
        {
            get;
            set;
        } = 100;
        public override int MaxHealth => 150;
        public override int Damage => 15;
        public override char DefaultChar => '%';
    }
}