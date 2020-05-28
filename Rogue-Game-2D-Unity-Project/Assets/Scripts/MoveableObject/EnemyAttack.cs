using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public int damage = 10;
    public Vector2 attackRange;
    private int angle = 0;

    public float timeBtwEnemyAttack;
    private float curTimeBtwEnemyAttack;

    void Update()
    {
        if(curTimeBtwEnemyAttack <= 0)
        {
            Collider2D[] Player = Physics2D.OverlapBoxAll(attackPos.position, attackRange, angle, whatIsPlayer);
            for (int i = 0; i < Player.Length; i++)
            Player[i].GetComponent<PlayerInfo>().TakeDamage(damage);

            curTimeBtwEnemyAttack = timeBtwEnemyAttack;
        }
        else
        {
            curTimeBtwEnemyAttack -= Time.deltaTime;
        }
        
    }

    void OnDrawGizmosSelected() //Visualizes the attack for testing
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, (Vector3)attackRange);

    }
}
