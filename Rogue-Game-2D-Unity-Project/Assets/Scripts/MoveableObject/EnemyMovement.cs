using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float moveSpeed = 2f;
    private Vector2 movement;
    public int movementType = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 direction = player.position - transform.position; //saves the direction from the Enemy to the player in "direction"
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //calculates the angle at which the enemy has to spin in order to stay in line with the player
            rb.rotation = angle; //spins the enemy;
            direction.Normalize(); //Brings the value of "direction" between "-1" and "1" for the movement function
            movement = direction;
        }
    }

    private void FixedUpdate() //Moves the Enemy
    {
        if (movementType == 1)
        {
            moveToPlayer(movement);
        }
        else if (movementType == 2)
        {
            moveFromPlayer(movement);
        }

    }

    void moveToPlayer(Vector2 direction) //Moves Enemy towards the player
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void moveFromPlayer(Vector2 direction) //Moves Enemy away from player
    {
        rb.MovePosition((Vector2)transform.position + (direction * -1 * moveSpeed * Time.deltaTime));
    }
}
