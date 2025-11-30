using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstacle : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CarMovementScript car = other.GetComponent<CarMovementScript>();
            if (car != null)
            {
                car.Die();   // Properly kills and restarts
            }
        }
    }
}