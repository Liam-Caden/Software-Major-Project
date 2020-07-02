using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    //sets up enemy states
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    //Set up variables
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public LootTable thisLoot;

    private void Awake()
    {
        //sets enemy health
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        //enemy takes damage
        health = health - damage;
        if(health <= 0)
        {
            //enemy dies and drops loot
            MakeLoot();
            this.gameObject.SetActive(false);  
		}
	}

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        //when enemy is hit take knockback and damage
     StartCoroutine(KnockCo(myRigidbody, knockTime));
     TakeDamage(damage);
	}

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if(myRigidbody != null)
        {
            // staggers the enemy
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
		}
	}

    private void MakeLoot()
    {
        //drops loot
        if(thisLoot != null)
        {
            powerup current = thisLoot.LootPowerup();
            if(current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
