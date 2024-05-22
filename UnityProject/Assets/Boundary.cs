using UnityEngine;

public class Boundary : MonoBehaviour
{
    // Reference to the player's Rigidbody component
    public Rigidbody2D playerRigidbody;

    // Maximum x-position allowed for the player (left boundary)
    public float minXPosition;

    // Maximum x-position allowed for the player (right boundary)
    public float maxXPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Get the player's current position
            Vector2 playerPosition = playerRigidbody.position;

            // Clamp the player's x-position within the specified boundaries
            playerPosition.x = Mathf.Clamp(playerPosition.x, minXPosition, maxXPosition);

            // Update the player's position
            playerRigidbody.position = playerPosition;
        }
    }
}
