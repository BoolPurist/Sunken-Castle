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
    public int maxHealth = 100;
    [HideInInspector]
    public int currentHealth;

    [HideInInspector]
    public bool isDead;



    public int CurrentHealth
    {
        get { return this.currentHealth; }
    }

    private void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();
        this.currentHealth = this.maxHealth;
        this.OnHealthChanges += GameObject.FindWithTag("GUIHealth").GetComponent<UpdateStatsText>().CallbackUpdateStats;
        this.OnDeathPlayer += GameObject.FindWithTag("MainCamera").GetComponent<ManageGameOverScreen>().CallbackCreateGameOverScreen;
        this.OnHealthChanges.Invoke(CurrentHealth);
    }

    private void Update()
    {
        // Checks if player dies.
        if (this.currentHealth <= 0)
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
            this.currentHealth = 0;
            OnHealthChanges.Invoke(CurrentHealth);
            // Triggers game over screen and disables toggling pause menu.
            OnDeathPlayer.Invoke(this, EventArgs.Empty);

            Destroy(this.gameObject, 2f);
        }

    }

    public void TakeDamage(int damage)
    {
        // Gives visuell feedback to player for player being hit.
        this.animator.SetTrigger("IsHit");
        this.currentHealth -= damage;
        // Updates health gui on the player view.
        OnHealthChanges.Invoke(CurrentHealth);
    }

    public void GainHealth(int health)
    {
        // Checks that the player does not gain more health than his max health.
        if (this.currentHealth + health >= 100)
        {
            this.currentHealth = 100;
        }
        else
        {
            this.currentHealth += health;
        }
        // Updates gui for player health
        OnHealthChanges.Invoke(CurrentHealth);

    }


}

