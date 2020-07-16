using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;
    public bool allowToMove = true;

    // Start is called before the first frame update
    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.LeftArrow) == false
            && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false) // Doesn't accept movement input from the arrow keys as they are for attacking
        {
            this.movement.x = Input.GetAxisRaw("Horizontal");
            this.movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            this.movement.x = 0;
            this.movement.y = 0;
        }

    }

    private void FixedUpdate()
    {
        if (this.allowToMove)
        {
            this.rb.MovePosition(this.rb.position + this.movement.normalized * this.moveSpeed * Time.fixedDeltaTime); //moves the character
        }

        this.animator.SetFloat("Horizontal", movement.x);
        this.animator.SetFloat("Vertical", movement.y);
        this.animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
