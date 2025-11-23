using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovementScript : MonoBehaviour
{
    bool alive = true;

    public float carSpeed = 3;
    public float horizontalSpeed = 4;
    public float rightLimit= 4.4f;
    public float leftLimit=-4.4f;
    
    void Update()
    {
        if(!alive) return;
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

    public void Die()
    {
        alive = false;
        Invoke ("Restart", 2);
    }


    void Restart()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
