using UnityEngine;

public class GroundSection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GroundSpawner spawner;
    void Start()
    {
        spawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other)
    {
        spawner.SpawnSection();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
       int obstacleSpawnIndex = Random.Range(2, 5); 
       Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
    Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}

