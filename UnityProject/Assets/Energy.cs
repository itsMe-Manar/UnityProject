using UnityEngine;

public class Energy : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding with the coin is the player
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.energie);
            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
