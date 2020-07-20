using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public delegate void OnHealthChange(int number);
    public event OnHealthChange OnHealthChanges;
    public event EventHandler OnDeathPlayer;

    public Animator animator;
    public static int maxHealth = 100;
    private static int currentHealth;
    [HideInInspector]
    public bool isDead;



    public int CurrentHealth
    {
        get => PlayerInfo.currentHealth;
        set
        {
            PlayerInfo.currentHealth = value;
            GameStats.currentPlayerHealth = value;
        }
    }

    private void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();

        // Need to update the score text otherwise the current score is not shown until the 1. enemy is slain.
        GameObject.FindGameObjectWithTag("GUIScore").GetComponent<UpdateStatsText>().CallbackUpdateStats(GameStats.score);
        // If -1 the game just started and the health must be set with the max Health form the unity inspector. 
        if (GameStats.currentPlayerHealth == -1)
        {
            this.CurrentHealth = PlayerInfo.maxHealth;
        }

        this.OnHealthChanges += GameObject.FindWithTag("GUIHealth").GetComponent<UpdateStatsText>().CallbackUpdateStats;
        this.OnDeathPlayer += GameObject.FindWithTag("MainCamera").GetComponent<ManageGameOverScreen>().CallbackCreateGameOverScreen;
        this.OnHealthChanges.Invoke(this.CurrentHealth);
    }

    private void Update()
    {
        // Checks if player dies.
        if (this.CurrentHealth <= 0)
        {
            if (this.isDead == false)
            {
                // Plays death animation. 
                this.animator.SetTrigger("Dies");
                // Makes sure that the death animation is not played more than once.
                this.isDead = true;
                // Prevents the player moving in his death animation via player input.
                GetComponent<PlayerMovement>().allowToMove = false;
            }
            // Prevents the display of health to show a negativ number.
            this.CurrentHealth = 0;
            OnHealthChanges.Invoke(CurrentHealth);
            // Triggers game over screen and disables toggling pause menu.
            OnDeathPlayer.Invoke(this, EventArgs.Empty);
            this.CurrentHealth = PlayerInfo.maxHealth;
            Destroy(this.gameObject, 2f);
        }

    }

    public void TakeDamage(int damage)
    {
        // Gives visuell feedback to player for player being hit.
        this.animator.SetTrigger("IsHit");
        this.CurrentHealth -= damage;
        // Updates health gui on the player view.
        OnHealthChanges.Invoke(CurrentHealth);
    }

    public void GainHealth(int health)
    {
        // Checks that the player does not gain more health than his max health.
        if (this.CurrentHealth + health >= 100)
        {
            this.CurrentHealth = 100;
        }
        else
        {
            this.CurrentHealth += health;
        }
        // Updates gui for player health
        OnHealthChanges.Invoke(this.CurrentHealth);

    }


}

