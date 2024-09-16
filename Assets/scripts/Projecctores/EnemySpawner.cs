using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;    
    public float spawnInterval = 10f;  
    public Transform[] spawnPoints;   

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}