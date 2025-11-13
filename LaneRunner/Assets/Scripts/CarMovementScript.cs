using UnityEngine;

public class CarMovementScript : MonoBehaviour
{

    public float carSpeed = 3;
    public float horizontalSpeed = 4;
    public float rightLimit= 4.4f;
    public float leftLimit=-4.4f;
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * carSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit) 
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed );
            }
        }
    }
}
