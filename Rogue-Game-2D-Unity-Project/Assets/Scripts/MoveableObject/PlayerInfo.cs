using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public delegate void OnHealthChange(int number);
    public event OnHealthChange OnHealthChanges;
    public event EventHandler OnDeathPlayer;
    public Animator animator;
    public int maxHealth = 100;
    private int currentHealth;

    [HideInInspector]
    public bool isDead;


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
            if (isDead == false)
            {
                animator.SetTrigger("Dies");
                isDead = true;
            }
            currentHealth = 0;
            OnHealthChanges.Invoke(CurrentHealth);
            OnDeathPlayer.Invoke(this, EventArgs.Empty);
            GetComponent<PlayerMovement>().allowToMove = false;
            GetComponent<CameraFollow>().allowToUpdate = false;
            Destroy(gameObject, 2f);
            gameObject.AddComponent<Camera>();
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

