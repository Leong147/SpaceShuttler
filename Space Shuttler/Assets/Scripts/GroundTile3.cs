using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile3 : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject[] ObstaclePrefabs;
    public GameObject CoinPrefab;
    Transform spawnPoint;
    Transform spawnPoint2;
    Transform spawnPoint3;
    int obstacleSpawnIndex;
    int obstacleSpawnIndex2;
    int obstacleSpawnIndex3;

    int RandomObs;

    // Start is called before the first frame update
    void Start()
    {
        //RandomObs = Random.Range(0, ObstaclePrefabs.Length);

        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
        SpawnSecondObstacles();
        SpawnThirdObstacles();
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

    void SpawnThirdObstacles()
    {
        RandomObs = Random.Range(0, ObstaclePrefabs.Length);
        obstacleSpawnIndex3 = Random.Range(4, 9);
        if (obstacleSpawnIndex3 != obstacleSpawnIndex && obstacleSpawnIndex3 != obstacleSpawnIndex2)
        {
            spawnPoint3 = transform.GetChild(obstacleSpawnIndex3);
            Instantiate(ObstaclePrefabs[RandomObs], spawnPoint3.position, Quaternion.identity, transform);
        }   
    }
}
