using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public bool isAlive = true;
    
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; 
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

