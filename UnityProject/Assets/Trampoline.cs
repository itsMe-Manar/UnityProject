using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // Adjust this value to change the strength of the jump
    public float jumpForce = 10f;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Make sure this method is called only when player enters the trigger area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object entering the trigger is the player
        if (collision.gameObject.CompareTag("Player"))
        {

            audioManager.PlaySFX(audioManager.trampoline);
            // Get the Rigidbody2D component of the player
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Apply an upward force to the player
            if (playerRb != null)
            {
                // Zero out the player's vertical velocity to prevent stacking forces
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
                
                // Apply the jump force
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
