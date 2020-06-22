using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public delegate void OnDeathEnemy(int number);
    public event OnDeathEnemy OnDeathEnemies;
    public Animator animator;
    private bool isDead = false;

    public int score = 100;
    public int maxHealth = 100;
    private int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        OnDeathEnemies += GameObject.FindWithTag("GUIScore").GetComponent<UpdateStatsText>().CallbackUpdateStatsAdd;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0 && isDead == false) 
        {
            Die();
        }
    }

    public void TakeDamage(int damage) //Function which reduces the health of an enemy, gets called in the PlayerAttack script
    {
        animator.SetTrigger("TakesDamage");
        currentHealth -= damage;
    }

    public void Die()
    {
        GetComponent<EnemyAI>().allowedToMove = false;
        if (isDead == false)
            OnDeathEnemies.Invoke(score);
        isDead = true;
        GetComponent<EnemyAttack>().allowToAttack = false;
        animator.SetTrigger("Dies");
        Destroy(gameObject, 2f);
    }


}
