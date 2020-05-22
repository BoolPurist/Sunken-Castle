﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public delegate void OnDeathEnemy(int number);
    public event OnDeathEnemy OnDeathEnemies;

    public int score = 100;
    public int maxHealth = 100;
    private int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    void Start()
    {
        OnDeathEnemies += GameObject.FindWithTag("GUIScore").GetComponent<UpdateStatsText>().CallbackUpdateStatsAdd;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0) //ADD EVENT
        {
            OnDeathEnemies.Invoke(score);
            Destroy(gameObject); //If health is, or is below 0, destroy the object
        }
    }

    public void TakeDamage(int damage) //Function which reduces the health of an enemy, gets called in the PlayerAttack script
    {
        currentHealth -= damage;
        Debug.Log("damage TAKEN"); //Debugging notification for testing
    }


}
