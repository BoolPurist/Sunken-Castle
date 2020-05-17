using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float moveSpeed = 2f;
    private Vector2 movement;

    public int MaxHealth = 100;
    private int currentHealth = 100;
    public bool isAlive = true;

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
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize(); //Brings the value of "direction" between "-1" and "1" for the movement function
        movement = direction;
    }

    private void FixedUpdate() //
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
