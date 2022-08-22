using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile1: MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject[] ObstaclePrefabs;
    public GameObject CoinPrefab;
    Transform spawnPoint;
    Transform spawnPoint2;
    int obstacleSpawnIndex;
    int obstacleSpawnIndex2;

    int RandomObs;

    // Start is called before the first frame update
    void Start()
    {
        RandomObs = Random.Range(0, ObstaclePrefabs.Length);

        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
        //SpawnSecondObstacles();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacles()
    {
        RandomObs = Random.Range(0, ObstaclePrefabs.Length);
        obstacleSpawnIndex = Random.Range(4,9);
        spawnPoint = transform.GetChild(obstacleSpawnIndex);

        Instantiate(ObstaclePrefabs[RandomObs], spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnSecondObstacles()
    {
        RandomObs = Random.Range(0, ObstaclePrefabs.Length);
        obstacleSpawnIndex2 = Random.Range(4, 9);
        if (obstacleSpawnIndex2 != obstacleSpawnIndex)
        {
            spawnPoint2 = transform.GetChild(obstacleSpawnIndex2);
                Instantiate(ObstaclePrefabs[RandomObs], spawnPoint2.position, Quaternion.identity, transform);
        }       
    }
}
