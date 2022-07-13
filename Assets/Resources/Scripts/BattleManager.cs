using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public enum Action { CHOOSING, ATTACK, MOVE }

public class BattleManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerSpawn;
    public Transform enemySpawn;

    public BattleState state;
    public Action action;

    Entity player;
    Entity enemy;

    public Text nameplate;

    void Start()
    {
        state = BattleState.START;
        action = Action.CHOOSING;
        StartCoroutine(SetupBattle());
    }
    
    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        player = playerGO.GetComponent<Entity>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemy = enemyGO.GetComponent<Entity>();

        nameplate.text = enemy.entityName;

        yield return new WaitForSeconds(4f);

        PlayerTurn();
    }

    public void PlayerTurn()
    {
        state = BattleState.PLAYERTURN;
        player.currentActionPoints = player.maxActionPoints;

        Debug.Log("Choose an action");
    }

    IEnumerator PlayerAttack()
    {
        Debug.Log("Player attacks!");

        bool isDead = enemy.TakeDamage(player.damage);
        //Damage the enemy

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }

        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        //Check if the enemy is dead
        //Change state
    }

    public IEnumerator EnemyTurn()
    {
        state = BattleState.ENEMYTURN;
        Debug.Log("Enemy attacks!");

        yield return new WaitForSeconds(1f);

        bool isDead = player.TakeDamage(enemy.damage);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }

        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            Debug.Log("You won!");
        }

        else if (state == BattleState.LOST)
        {
            Debug.Log("You were defeated.");
        }
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnMoveButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        if (action == Action.MOVE)
        {
            action = Action.CHOOSING;
            return;
        }

        action = Action.MOVE;
        StartCoroutine(player.GetComponent<PlayerController>().movePlayer());
    }
}
