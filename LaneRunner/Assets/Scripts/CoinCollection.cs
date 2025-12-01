using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private int coin = 0;

    [SerializeField] TextMeshProUGUI coinText;     // assign in Inspector
    [SerializeField] AudioSource coinFX;           // assign in Inspector

    private void Start()
    {
        if (coinText != null)
        {
            coinText.text = "Coin: 0";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Car trigger hit: " + other.name + " | tag: " + other.tag);

        // Only react to objects tagged as "Coin"
        if (!other.CompareTag("Coin")) return;

        // Play sound if assigned
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

        // Destroy the coin
        Destroy(other.gameObject);
    }
}
