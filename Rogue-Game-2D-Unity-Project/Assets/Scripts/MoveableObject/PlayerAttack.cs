using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float timeBtwAttacks; //Time the player has to wait before attacking again, public so changeable by the designer (in seconds, so value 5f means 5 seconds)
    private float curTimeBtwAttacks; //Time until the next attack can be started
    public Animator animator;
    
    public Transform attackPosRight; //Position of the attack
    public Transform attackPosLeft;
    public Transform attackPosUp;
    public Transform attackPosDown; 

    public float attackRange; //Range of the attack
    public int damage; //Damage dealt to enemies in radius
    public LayerMask whatIsEnemy; 

    private void Update()
    {
        if(curTimeBtwAttacks <= 0) //If the minimal time between two attacks has passed, you can attack
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosRight.position, attackRange, whatIsEnemy);
                //Circle gets cast at certain position, all enemies in the circle get put into array enemiesToDamage, which will take damage

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyInfo>().TakeDamage(damage);
                }
                animator.SetTrigger("IsAttackingRight");
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosLeft.position, attackRange, whatIsEnemy);
                //Circle gets cast at certain position, all enemies in the circle get put into array enemiesToDamage, which will take damage

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyInfo>().TakeDamage(damage);
                }
                animator.SetTrigger("IsAttackingLeft");
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosUp.position, attackRange, whatIsEnemy);
                //Circle gets cast at certain position, all enemies in the circle get put into array enemiesToDamage, which will take damage

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyInfo>().TakeDamage(damage);
                }
                animator.SetTrigger("IsAttackingUp");
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosDown.position, attackRange, whatIsEnemy);
                //Circle gets cast at certain position, all enemies in the circle get put into array enemiesToDamage, which will take damage

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyInfo>().TakeDamage(damage);
                }
                animator.SetTrigger("IsAttackingDown");
            }
            curTimeBtwAttacks = timeBtwAttacks; //After the attack, Timer gets set back
        }
        else
        {
            curTimeBtwAttacks -= Time.deltaTime; //Time gets reduced by time passed
        }
    }

    private void OnDrawGizmosSelected() //Visualizes the attack for testing
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosRight.position, attackRange);

    }
}
