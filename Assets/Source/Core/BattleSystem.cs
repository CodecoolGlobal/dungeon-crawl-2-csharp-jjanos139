using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] public GameObject playerUnit;
    [SerializeField] public GameObject enemyUnit;
    [SerializeField] public PlayerHud playerHud;
    [SerializeField] public PlayerHud enemyHud;



    public void SetupBattle(int id, Actor Enemy, Actor player)
    {

        playerUnit = GameObject.Find("PlayerUnit");
        playerUnit.GetComponent<Image>().sprite = ActorManager.Singleton.GetSprite(24);
        enemyUnit = GameObject.Find("EnemyPlayer");
        enemyUnit.GetComponent<Image>().sprite = ActorManager.Singleton.GetSprite(id);



        //PlayerUnit = player.GetSprite();
        //EnemyUnit = new PlayerUnit();
        //PlayerHud = new PlayerHud();
        //EnemyHud = new PlayerHud();
        //playerUnit.Setup(24);

        //var playerCords = ActorManager.Singleton.GetPlayerCoords();
        //playerHud.SetData(player);
        //enemyHud.SetData(Enemy);
    }
}