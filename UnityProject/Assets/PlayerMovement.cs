using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2; // Maximum number of jumps (including the initial jump)
    public Animator animator;
    float horizontalInput;
    private Vector2 startPosition; // Starting position
    private Rigidbody2D rb;
    private Vector2 movement; // Define movement vector here
    private bool isGrounded = false; // To check if the player is grounded
    private bool facingRight = true; // To track which direction the player is facing
    private int jumpsRemaining; // Number of jumps remaining

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = rb.position; // Set the initial position
        Debug.Log("Player Start Position: " + startPosition);

        jumpsRemaining = maxJumps; // Initialize jumps remaining
    }

    void Update()
    {
        // Capture player horizontal movement input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Update animator parameters based on movement


        // Check if the player is not moving and stop animation


        // Flip the character to face the direction of movement
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || jumpsRemaining > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpsRemaining--;
                isGrounded = false;
                animator.SetBool("isJumping", !isGrounded);

                // Play jump animation or set animator parameters
            }
        }
    }

    void FixedUpdate()
    {

        // Move the player based on input
        rb.velocity = new Vector2(movement.x, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", Math.Abs(rb.velocity.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
        if (other.gameObject.CompareTag("Coin"))
        {
            // Destroy the coin and possibly update the score
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Spike"))
        {
            // Reset player position to the start position
            rb.position = startPosition;
            transform.position = startPosition;
            jumpsRemaining = maxJumps; // Reset jumps remaining
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
             // Player is grounded when colliding with the floor
            jumpsRemaining = maxJumps; // Reset jumps remaining on ground contact
        }
    }

    

    private void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1 to flip the sprite
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
