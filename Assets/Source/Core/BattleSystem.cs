using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

    public class BattleSystem : MonoBehaviour
    {
        [SerializeField] public PlayerUnit PlayerUnit;
        [SerializeField] public PlayerUnit EnemyUnit;
        [SerializeField] public PlayerHud PlayerHud;
        [SerializeField] public PlayerHud EnemyHud;

        public void SetupBattle(int id, Actor actor)
        {
            PlayerUnit.Setup(24);
            EnemyUnit.Setup(id);
            var playerCords = ActorManager.Singleton.GetPlayerCoords();
            PlayerHud.SetData(ActorManager.Singleton.GetActorAt(playerCords));
            EnemyHud.SetData(actor);
        }
    }
