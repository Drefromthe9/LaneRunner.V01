using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject groundSection;
    Vector3 nextSpawnPoint;

     public void SpawnSection()
    {
        GameObject temp = Instantiate(groundSection, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).position;
    }
    void Start()
    {
        for (int i = 0; i < 15; i++)
        SpawnSection();
    }

    // Update is called once per frame
   
}