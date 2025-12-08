using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovementScript : MonoBehaviour
{
    bool alive = true;

    public float carSpeed = 3;
    public float maxSpeed= 25f;
    public float increaseStartTime = 5f;
    public float acceleration = 2f;

    private bool canAccelerate = false;
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
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed); // Move left
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // Move right
        {
            if (this.gameObject.transform.position.x < rightLimit) 
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed ); 
            }
        }

        if(Time.time >= increaseStartTime) // Start acceleration after delay
        {
            canAccelerate = true;
        }   
        if(canAccelerate && carSpeed < maxSpeed) // Accelerate up to max speed
        {
            carSpeed += acceleration * Time.deltaTime;
        }
    }

   public void Die()// Handle car death
{
    
    if (ScoreManager.Instance != null)
        ScoreManager.Instance.EndGameAndSaveScore(); // Save score on death

   
    SceneManager.LoadScene("GameOverScene"); // Reload current scene
}


}
