using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

using UnityEngine;
using UnityEngine.UI;


public enum BattleStatus {Start, PlayerMove, EnemyMove, Busy}
public class BattleSystem : MonoBehaviour
{
    [SerializeField] public GameObject playerUnit;
    [SerializeField] public GameObject enemyUnit;
    [SerializeField] public GameObject playerHud;
    [SerializeField] public GameObject enemyHud;
    [SerializeField] DialogBox battledialog = new DialogBox();
    public BattleStatus state;
    private int currentAction;

    public void SetupBattle(int id, Actor enemy, Actor player)
    {

        playerUnit = GameObject.Find("PlayerUnit");
        playerUnit.GetComponent<PlayerUnit>().Unit = player;
        playerUnit.GetComponent<Image>().sprite = ActorManager.Singleton.GetSprite(24);
        enemyUnit = GameObject.Find("EnemyPlayer");
        enemyUnit.GetComponent<PlayerUnit>().Unit = enemy;
        enemyUnit.GetComponent<Image>().sprite = ActorManager.Singleton.GetSprite(id);
        playerHud = GameObject.Find("PlayerHud");
        playerHud.GetComponent<PlayerHud>().Name.text = player.DefaultName;
        enemyHud = GameObject.Find("EnemyHud");
        enemyHud.GetComponent<PlayerHud>().Name.text = enemy.DefaultName;
        enemyHud.GetComponent<PlayerHud>().Hpbar.SetHP(1);
        var cams = GameObject.FindObjectsOfType(typeof(Camera));
        foreach (Camera cam in cams)
        {
            if (cam.name == "BattleCamera")
            {
                cam.enabled = true;
            }
        }
        //float phealth = playerUnit.GetComponent<PlayerUnit>().Unit.Health;
        //float pmaxHealth = playerUnit.GetComponent<PlayerUnit>().Unit.MaxHealth;
        //playerHud.GetComponent<PlayerHud>().Hpbar.SetHP((float)phealth / pmaxHealth);
        PlayerAction();
    }

    private void PlayerAction()
    {
        state = BattleStatus.PlayerMove;
    }

    private void Update()
    {
        if (state == BattleStatus.PlayerMove)
        {
            HandleActionSelection();
        }
    }

    public void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            if (currentAction < 1)
            {
                currentAction++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            if (currentAction > 0)
            {
                currentAction--;
            }
        }
        battledialog.UpdateActionSelection(currentAction);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PerformPlayerMove();
        }
    }

    private void PerformPlayerMove()
    {
        if (state == BattleStatus.PlayerMove)
        {
            enemyUnit.GetComponent<PlayerUnit>().Unit.ApplyDamage(playerUnit.GetComponent<PlayerUnit>().Unit);
            float health = enemyUnit.GetComponent<PlayerUnit>().Unit.Health;
            float maxHealth = enemyUnit.GetComponent<PlayerUnit>().Unit.MaxHealth;
            enemyHud.GetComponent<PlayerHud>().Hpbar.SetHP((float) health / maxHealth);
            state = BattleStatus.EnemyMove;
        }
        if (state == BattleStatus.EnemyMove)
        {
            playerUnit.GetComponent<PlayerUnit>().Unit.ApplyDamage(enemyUnit.GetComponent<PlayerUnit>().Unit);
            float phealth = playerUnit.GetComponent<PlayerUnit>().Unit.Health;
            float pmaxHealth = playerUnit.GetComponent<PlayerUnit>().Unit.MaxHealth;
            playerHud.GetComponent<PlayerHud>().Hpbar.SetHP((float) phealth/pmaxHealth);
            state = BattleStatus.PlayerMove;
        }
        
    }
}

