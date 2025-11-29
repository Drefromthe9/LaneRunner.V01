using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{

    private int Coin = 0;

    public TextMeshProUGUI coinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Coin")
        {
            Coin ++;
            coinText.text = "Coin: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(other.gameObject);
        }
    }
}
