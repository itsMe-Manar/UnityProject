using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding with the coin is the player
        if (collision.CompareTag("Player"))
        {
            // Destroy the coin
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(value);
        }
    }
}
