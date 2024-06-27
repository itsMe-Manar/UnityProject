using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioManager audioManager;

    public int value;
    private void Awake()
    {
       
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();  
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding with the coin is the player
        if (collision.CompareTag("Player"))
        {
           audioManager.PlaySFX(audioManager.coins);
            // Destroy the coin
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(value);
        }
    }
}
