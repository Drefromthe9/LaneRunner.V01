using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    [SerializeField] float spinSpeed = 90f; // Degrees per second
    void Update()
    {
        transform.Rotate(0, spinSpeed, 0, Space.World); // Spin the coin around the Y-axis
    }
}
