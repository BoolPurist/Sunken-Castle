using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public delegate void OnHealthChange(int number);
    public event OnHealthChange OnHealthChanges;
    public event EventHandler OnDeathPlayer;
    public Animator animator;
    public bool isDead;


    public int maxHealth = 100;
    private int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
        OnHealthChanges += GameObject.FindWithTag("GUIHealth").GetComponent<UpdateStatsText>().CallbackUpdateStats;
        OnDeathPlayer += GameObject.FindWithTag("MainCamera").GetComponent<ManageGameOverScreen>().CallbackCreateGameOverScreen;
        OnHealthChanges.Invoke(CurrentHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            if(isDead == false)
            {
                animator.SetTrigger("Dies");
                isDead = true;
            }       
            currentHealth = 0;
            OnHealthChanges.Invoke(CurrentHealth);
            OnDeathPlayer.Invoke(this, EventArgs.Empty);
            Destroy(gameObject,2f);
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("IsHit");
        currentHealth -= damage;
        OnHealthChanges.Invoke(CurrentHealth);
    }

    public void GainHealth(int health)
    {
        if (currentHealth + health >= 100)
        {
            currentHealth = 100;
        }
        else
        {
            currentHealth += health;
        }
        OnHealthChanges.Invoke(CurrentHealth);
    }


}

