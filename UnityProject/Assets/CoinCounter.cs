using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coinText;
    public int currentCoins=0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;  
        coinText.text="COINS: " + currentCoins.ToString();
    }
}
