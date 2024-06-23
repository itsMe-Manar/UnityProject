using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    private Vector2 startPosition; // Starting position

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position; // Set the initial position
    }

    void Update()
    {
        // Capture player movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector to prevent faster diagonal movement
        movement.Normalize();

        // Update animator parameters based on movement
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        // Check if the player is not moving and stop animation
        if (movement.magnitude == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
    }

    void FixedUpdate()
    {
        // Move the player based on input
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
        }
    }
}
