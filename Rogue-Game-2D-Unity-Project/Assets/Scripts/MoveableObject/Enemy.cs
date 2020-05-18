using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float moveSpeed = 2f;
    private Vector2 movement;

    public int maxHealth = 100;
    private int currentHealth;
    public bool isAlive = true;
    public int attackType = 1;

    public Enemy()
    {
        currentHealth = maxHealth;
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position; //saves the direction from the Enemy to the player in "direction"
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //calculates the angle at which the enemy has to spin in order to stay in line with the player
        rb.rotation = angle; //spins the enemy;
        direction.Normalize(); //Brings the value of "direction" between "-1" and "1" for the movement function
        movement = direction;
    }

    private void FixedUpdate() //Moves the Enemy
    {
        if(attackType == 1)
        {
            moveToPlayer(movement);
        }
        else if(attackType == 2)
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
        rb.MovePosition(-1 * (Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
