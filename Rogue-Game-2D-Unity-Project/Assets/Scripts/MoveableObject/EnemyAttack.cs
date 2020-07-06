﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyPowerGainPerLevel
{
    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public int damage = 10;
    public Vector2 attackRange;
    private int angle = 0;
    private Animator anim;


    public float timeBtwEnemyAttack;
    private float curTimeBtwEnemyAttack;
    [HideInInspector]
    public bool allowToAttack = true;


    private new void Start()
    {
        base.Start();

        // Increasing the damage of the enemy depending the level already done by player.
        this.damage = base.WholeNumberStatFromPowerGain(this.damage);
        this.anim = this.gameObject.GetComponent<Animator>();
    }
    private new void Update()
    {
        base.Update();

        if (curTimeBtwEnemyAttack <= 0 && allowToAttack)
        {
            Collider2D Player = Physics2D.OverlapBox(attackPos.position, attackRange, angle, whatIsPlayer);

            if (Player != null)
            {
                this.curTimeBtwEnemyAttack = this.timeBtwEnemyAttack;
                StartCoroutine("TryToAttack");
            }
        }
        else
        {
            this.curTimeBtwEnemyAttack -= Time.deltaTime;
            Debug.Log(this.anim);
            this.anim.ResetTrigger("Attacking");
        }

    }

    void OnDrawGizmosSelected() //Visualizes the attack for testing
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, (Vector3)attackRange);

    }

    IEnumerator TryToAttack()
    {
        this.anim.SetTrigger("Attacking");

        yield return new WaitForSeconds(0.8f);

        Collider2D Player = Physics2D.OverlapBox(attackPos.position, attackRange, angle, whatIsPlayer);

        if (Player != null && this.allowToAttack == true)
        {
            Player.GetComponent<PlayerInfo>().TakeDamage(damage);
            if (Player.GetComponent<PlayerInfo>().CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }


    }
}
