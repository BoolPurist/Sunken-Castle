﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public delegate void OnHealthChange (int number);
    public event OnHealthChange OnHealthChanges;
    public event EventHandler OnDeathPlayer;


    public int maxHealth = 100;
    private int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanges += GameObject.FindWithTag("GUIHealth").GetComponent<UpdateStatsText>().CallbackUpdateStats;
        OnDeathPlayer += GameObject.FindWithTag("MainCamera").GetComponent<ManageGameOverScreen>().CallbackCreateGameOverScreen;
        OnHealthChanges.Invoke(CurrentHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            OnDeathPlayer.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnHealthChanges.Invoke(CurrentHealth);
    }


}
