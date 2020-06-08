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
    private Animator anim;


    public float timeBtwEnemyAttack;
    private float curTimeBtwEnemyAttack;
    [HideInInspector]
    public bool allowToAttack = true;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (curTimeBtwEnemyAttack <= 0 && allowToAttack)
        {
            Collider2D[] Player = Physics2D.OverlapBoxAll(attackPos.position, attackRange, angle, whatIsPlayer);

            for (int i = 0; i < Player.Length; i++)
            {
                Player[i].GetComponent<PlayerInfo>().TakeDamage(damage);
                if (Player[i].GetComponent<PlayerInfo>().CurrentHealth <= 0)
                    Destroy(gameObject);
                anim.SetTrigger("Attacking");
            }


            curTimeBtwEnemyAttack = timeBtwEnemyAttack;
        }
        else
        {
            curTimeBtwEnemyAttack -= Time.deltaTime;
            anim.ResetTrigger("Attacking");
        }

    }

    void OnDrawGizmosSelected() //Visualizes the attack for testing
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, (Vector3)attackRange);

    }
}
