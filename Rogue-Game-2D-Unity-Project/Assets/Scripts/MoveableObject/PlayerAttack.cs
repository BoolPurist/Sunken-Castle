using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float timeBtwAttacks; //Time the player has to wait before attacking again, public so changeable by the designer (in seconds, so value 5f means 5 seconds)
    private float curTimeBtwAttacks; //Time until the next attack can be started

    public Transform attackPos; //Position of the attack
    public float attackRange; //Range of the attack
    public LayerMask whatIsEnemy;
    public int damage;

    void Update()
    {
        if(curTimeBtwAttacks <= 0) //If the minimal time between two attacks has passed, you can attack
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                //Circle gets cast at certain position, all enemies in the circle get put into array enemiesToDamage, which will take damage

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            curTimeBtwAttacks = timeBtwAttacks; //After the attack, Timer gets set back
        }
        else
        {
            curTimeBtwAttacks -= Time.deltaTime; //Time gets reduced by time passed
        }
    }

    void OnDrawGizmosSelected() //Visualizes the attack for testing
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }
}
