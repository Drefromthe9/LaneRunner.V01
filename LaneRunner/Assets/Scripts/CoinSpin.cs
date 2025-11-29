using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    [SerializeField] float spinSpeed = 90f;
    void Update()
    {
        transform.Rotate(0, spinSpeed, 0, Space.World);
    }
}
