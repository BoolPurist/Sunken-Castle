using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    
    public float moveSpeed = 2f;
    public int movementType = 1;
    public float triggerDistance = 5f;
    [HideInInspector]
    public bool allowedToMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);  //saves the distance between Player and Enemy

        if (player != null && allowedToMove == true && distance <= triggerDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized; //saves and normalizes the direction from the Enemy to the player in "direction"
            movement = direction;
        }
        else
        {
            movement = Vector2.zero;
        }

    }

    private void FixedUpdate() //Moves the Enemy
    {
        if (movementType == 1)
        {
            moveToPlayer(movement);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

        }
        else if (movementType == 2)
        {
            moveFromPlayer(-movement);
            animator.SetFloat("Horizontal", -movement.x);
            animator.SetFloat("Vertical", -movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

        }

    }

    void moveToPlayer(Vector2 direction) //Moves Enemy towards the player
    {

         rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void moveFromPlayer(Vector2 direction) //Moves Enemy away from player
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnDrawGizmosSelected() //Visualizes the trigger distance for testing
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerDistance);

    }
}
