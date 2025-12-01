using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin triggered by: " + other.name);   

        if (!other.CompareTag("Player")) return;         
        coinFX.Play();
        gameObject.SetActive(false);
    }
}
