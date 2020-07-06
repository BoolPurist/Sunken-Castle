using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : EnemyPowerGainPerLevel
{
    public delegate void DelegateUpdateStatGUI(int number);
    public event DelegateUpdateStatGUI OnDeathEnemiesScore;
    public event DelegateUpdateStatGUI OnSpawnEnemy;

    public event DelegateUpdateStatGUI OnDeathEnemiesCount;
    public Animator animator;
    public int score = 100;
    public int maxHealth = 100;

    private int currentHealth;
    private bool isDead = false;


    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    private new void Start()
    {
        base.Start();

        this.animator = this.GetComponent<Animator>();
        // Adding callback functions from the player gui to keep the stats which are shown the player in the gui, up-to-date.
        this.OnDeathEnemiesScore += GameObject.FindWithTag("GUIScore").GetComponent<UpdateStatsText>().CallbackUpdateStatsAdd;
        this.OnDeathEnemiesCount += GameObject.FindWithTag("GUIEnemyCount").GetComponent<UpdateStatsText>().CallbackUpdateStatsAdd;

        this.OnSpawnEnemy += GameObject.FindGameObjectWithTag("GUIEnemyCount").GetComponent<UpdateStatsText>().CallbackUpdateStatsAdd;

        // Increments the count for enemys left in the player gui.
        if (this.OnSpawnEnemy != null)
        {
            this.OnSpawnEnemy.Invoke(1);
        }

        // Increasing the health of the enemy depending the level already done by player.
        this.currentHealth = base.WholeNumberStatFromPowerGain(this.maxHealth);
    }

    private new void Update()
    {
        base.Update();

        if (this.currentHealth <= 0 && this.isDead == false)
        {
            Die();
        }
    }

    // Function which reduces the health of an enemy, gets called in the PlayerAttack script
    public void TakeDamage(int damage)
    {
        this.animator.SetTrigger("TakesDamage");
        this.currentHealth -= damage;
    }

    public void Die()
    {
        this.GetComponent<EnemyAI>().allowedToMove = false;

        if (isDead == false)
        {
            // Increases the score in the player gui.
            if (this.OnDeathEnemiesScore != null)
            {
                this.OnDeathEnemiesScore.Invoke(score);
            }

            // Decrements the count of enemy left in the player gui.
            if (this.OnDeathEnemiesCount != null)
            {

                this.OnDeathEnemiesCount.Invoke(-1);
            }
        }

        this.isDead = true;
        this.GetComponent<EnemyAttack>().allowToAttack = false;
        this.animator.SetTrigger("Dies");

        Destroy(gameObject, 2f);
    }


}
