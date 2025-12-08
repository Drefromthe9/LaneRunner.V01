using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private int coin = 0;

    [SerializeField] TextMeshProUGUI coinText;     
    [SerializeField] AudioSource coinFX;           
    private void Start()
    {
        if (coinText != null)
        {
            coinText.text = "Coin: 0"; // Initialize coin text
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Car trigger hit: " + other.name + " | tag: " + other.tag); // Debug line to see what we hit

        if (!other.CompareTag("Coin")) return; // Only proceed if we hit a coin

        if (coinFX != null)
        {
            coinFX.Play();
        }

        // Increase coin count and update UI
        coin++;
        if (coinText != null)
        {
            coinText.text = "Coin: " + coin;
        }

        // Tell ScoreManager to add points for this coin
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddCoinBonus(1); // 1 coin -> +10 points (configurable in ScoreManager)
        }

        // Destroy the coin after pickup
        Destroy(other.gameObject);
    }
}
