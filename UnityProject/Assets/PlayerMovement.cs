using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public Rigidbody2D rb;
    private int jumpCount;
    public int maxJumps = 2; // Maximum number of jumps (including the initial jump)
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);

        // Debug log for move input
        Debug.Log("Move Input: " + moveInput);

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            // Debug log for jump
            Debug.Log("Jump pressed");

            rb.velocity = new Vector2(rb.velocity.x, 0); // Reset y velocity before jumping
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCount--;

            // Debug log for jump count
            Debug.Log("Jump Count: " + jumpCount);
        }

        // Flip sprite based on movement direction
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            jumpCount = maxJumps; // Reset jump count when the player hits the ground

            // Debug log for ground collision
            Debug.Log("Landed on Floor");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;

            // Debug log for leaving ground
            Debug.Log("Left Floor");
        }
    }
}