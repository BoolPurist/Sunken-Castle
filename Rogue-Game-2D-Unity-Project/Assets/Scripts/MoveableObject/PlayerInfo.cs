using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public event EventHandler OnDeathPlayer;
    public event EventHandler OnHealthChange;
    public int maxHealth = 100;
    private int currentHealth;
    
    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    void Start()
    {      
        currentHealth = maxHealth; 
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            OnDeathPlayer(this, EventArgs.Empty);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnHealthChange(this, EventArgs.Empty);
    }

    
}

