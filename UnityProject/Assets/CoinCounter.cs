using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coinText;
    public int currentCoins = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    public void IncreaseCoins(int amount)
    {
        currentCoins += amount;
        UpdateCoinText();
    }

    public void ResetCoins()
    {
        currentCoins = 0;
        UpdateCoinText();
    }
}
