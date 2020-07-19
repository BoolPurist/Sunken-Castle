using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : EnemyPowerGainPerLevel
{

    public delegate void DelegateUpdateStatGUI(int number);
    public event DelegateUpdateStatGUI OnDeathEnemiesScore;
    public event DelegateUpdateStatGUI OnEnemyCountChange;

    public Animator animator;
    [Tooltip("Number added to the score when a enemy is killed.")]
    public int score = 100;
    [Tooltip("Amount of health the enemy stats with.")]
    public int maxHealth = 100;
    [Tooltip("Tag to find GUI element for showing score to the player")]
    public string TagForGUIScore;
    [Tooltip("Tag to find GUI element for showing left enemies to the player")]
    public string TagForGUIEnemiesLeft;
    public GameObject prefabDeathAnimation;

    private int currentHealth;

    public int CurrentHealth
    {
        get { return this.currentHealth; }
    }

    private new void Start()
    {
        base.Start();

        this.animator = this.GetComponent<Animator>();
        // Adding callback functions from the player gui to keep the stats which are shown the player in the gui, up-to-date.

        GameObject guiScore = GameObject.FindWithTag(this.TagForGUIScore);
        GameObject guiCount = GameObject.FindWithTag(this.TagForGUIEnemiesLeft);

        if (guiScore != null)
        {
            this.OnDeathEnemiesScore += guiScore.GetComponent<UpdateStatsText>().CallbackUpdateStatsAdd;
        }
        else
        {
            Debug.LogWarning($"No object with tag {this.TagForGUIScore} could not be found ! Score for killed enemies can not be updated in the player gui.");
        }

        if (guiCount != null)
        {
            this.OnEnemyCountChange += guiCount.GetComponent<UpdateStatsText>().CallbackUpdateStatsAdd;
        }
        else
        {
            Debug.LogWarning($"No object with tag {this.TagForGUIEnemiesLeft} could not be found ! Count for left enemies can not be updated in the player gui.");
        }



        // Increments the count for enemys left in the player gui.
        if (this.OnEnemyCountChange != null)
        {
            this.OnEnemyCountChange.Invoke(1);
        }

        // Increasing the health of the enemy depending the level already done by player.
        this.currentHealth = base.WholeNumberStatFromPowerGain(this.maxHealth);
    }

    private new void Update()
    {
        base.Update();

        if (this.currentHealth <= 0)
        {
            this.Die();
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
        // Increases the score in the player gui.
        if (this.OnDeathEnemiesScore != null)
        {
            this.OnDeathEnemiesScore.Invoke(this.score);
        }

        // Decrements the count of enemy left in the player gui.
        if (this.OnEnemyCountChange != null)
        {
            this.OnEnemyCountChange.Invoke(-1);
        }

        Instantiate(this.prefabDeathAnimation, this.GetComponent<Transform>().position, Quaternion.identity);

        Destroy(this.gameObject);
    }


}
