using Assets.Source.Actors.Items;
using DungeonCrawl.Actors;
using DungeonCrawl.Core;
using UnityEngine;
using UnityEngine.UI;


public enum BattleStatus { Start, PlayerMove, EnemyMove, Busy }
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
        playerUnit.GetComponent<Image>().sprite = ActorManager.Singleton.GetSprite(player.DefaultSpriteId);
        enemyUnit = GameObject.Find("EnemyPlayer");
        enemyUnit.GetComponent<PlayerUnit>().Unit = enemy;
        enemyUnit.GetComponent<Image>().sprite = ActorManager.Singleton.GetSprite(id);
        playerHud = GameObject.Find("PlayerHud");
        playerHud.GetComponent<PlayerHud>().Name.text = player.DefaultName;
        enemyHud = GameObject.Find("EnemyHud");
        enemyHud.GetComponent<PlayerHud>().Name.text = enemy.DefaultName;
        var cams = GameObject.FindObjectsOfType(typeof(Camera));
        foreach (Camera cam in cams)
        {
            if (cam.name == "BattleCamera")
            {
                cam.enabled = true;
            }
        }
        float phealth = playerUnit.GetComponent<PlayerUnit>().Unit.Health;
        float pmaxHealth = playerUnit.GetComponent<PlayerUnit>().Unit.MaxHealth;
        playerHud.GetComponent<PlayerHud>().Hpbar.SetHP((float)phealth / pmaxHealth);
        float ehealth = enemyUnit.GetComponent<PlayerUnit>().Unit.Health;
        float emaxHealth = enemyUnit.GetComponent<PlayerUnit>().Unit.MaxHealth;
        enemyHud.GetComponent<PlayerHud>().Hpbar.SetHP((float)ehealth / emaxHealth);
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
            bool hasPotion = false;
            Actor potion = null;

            if (playerUnit.GetComponent<PlayerUnit>()
                    .Unit.DefaultName ==
                "Player")
            {
                foreach (var item in playerUnit.GetComponent<PlayerUnit>()
                             .Unit.Inventory)
                {
                    if (item.DefaultName == "Potion")
                    {
                        hasPotion = true;
                        potion = item;
                    }
                }
            }
            else
            {
                foreach (var item in enemyUnit.GetComponent<PlayerUnit>()
                             .Unit.Inventory)
                {
                    if (item.DefaultName == "Potion")
                    {
                        hasPotion = true;
                        potion = item;
                    }
                }
            }

            if (hasPotion)
            {
                if (GameObject.Find("DialogBox").GetComponents<DialogBox>()[0].MoveTexts[0].color == Color.black)
                {
                    PerformPlayerMove("attack");
                }
                else if (GameObject.Find("DialogBox").GetComponents<DialogBox>()[0].MoveTexts[0].color ==
                         Color.blue)
                {
                    PerformPlayerMove("Heal", potion);
                }
            }
            else
            {
                PerformPlayerMove("attack");
            }

        }
    }

    private void PerformPlayerMove(string movetype, Actor potion = null)
    {
        if (movetype == "attack")
        {
            if (state == BattleStatus.PlayerMove)
            {
                enemyUnit.GetComponent<PlayerUnit>().Unit.ApplyDamage(playerUnit.GetComponent<PlayerUnit>().Unit.Damage);
                float health = enemyUnit.GetComponent<PlayerUnit>().Unit.Health;
                float maxHealth = enemyUnit.GetComponent<PlayerUnit>().Unit.MaxHealth;
                enemyHud.GetComponent<PlayerHud>().Hpbar.SetHP((float)health / maxHealth);
                state = BattleStatus.EnemyMove;
            }
            if (state == BattleStatus.EnemyMove)
            {
                playerUnit.GetComponent<PlayerUnit>().Unit.ApplyDamage(enemyUnit.GetComponent<PlayerUnit>().Unit.Damage);
                float phealth = playerUnit.GetComponent<PlayerUnit>().Unit.Health;
                float pmaxHealth = playerUnit.GetComponent<PlayerUnit>().Unit.MaxHealth;
                playerHud.GetComponent<PlayerHud>().Hpbar.SetHP((float)phealth / pmaxHealth);
                state = BattleStatus.PlayerMove;
            }
        }
        else
        {
            if (playerUnit.GetComponent<PlayerUnit>().Unit.DefaultName == "Player")
            {
                playerUnit.GetComponent<PlayerUnit>().Unit.ApplyDamage(potion.Damage);
                float phealth = playerUnit.GetComponent<PlayerUnit>().Unit.Health;
                float pmaxHealth = playerUnit.GetComponent<PlayerUnit>().Unit.MaxHealth;
                playerHud.GetComponent<PlayerHud>().Hpbar.SetHP((float) phealth / pmaxHealth);
                playerUnit.GetComponent<PlayerUnit>().Unit.Inventory.Remove(potion);
                ActorManager.Singleton.DestroyActor(potion);
            }
            else
            {
                enemyUnit.GetComponent<PlayerUnit>().Unit.ApplyDamage(potion.Damage);
                float phealth = enemyUnit.GetComponent<PlayerUnit>().Unit.Health;
                float pmaxHealth = enemyUnit.GetComponent<PlayerUnit>().Unit.MaxHealth;
                enemyHud.GetComponent<PlayerHud>().Hpbar.SetHP((float) phealth / pmaxHealth);
                enemyUnit.GetComponent<PlayerUnit>().Unit.Inventory.Remove(potion);
                ActorManager.Singleton.DestroyActor(potion);
            }

        }
    }
}

