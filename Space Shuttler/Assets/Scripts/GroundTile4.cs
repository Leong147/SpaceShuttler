using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile4 : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject[] ObstaclePrefabs;
    public GameObject CoinPrefab;

    Transform spawnPoint;
    Transform spawnPoint2;
    Transform spawnPoint3;
    Transform spawnPoint4;
    Transform spawnPoint5;

    int obstacleSpawnIndex;
    int obstacleSpawnIndex2;
    int obstacleSpawnIndex3;
    int obstacleSpawnIndex4;
    int obstacleSpawnIndex5;

    int RandomObs;

    // Start is called before the first frame update
    void Start()
    {
        RandomObs = Random.Range(0, ObstaclePrefabs.Length);

        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
        SpawnSecondObstacles();
        SpawnThirdObstacles();
        SpawnFourthObstacles();
        //SpawnFifthObstacles();
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
        obstacleSpawnIndex = Random.Range(4,9);

        spawnPoint = transform.GetChild(obstacleSpawnIndex);

        Instantiate(ObstaclePrefabs[RandomObs], spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnSecondObstacles()
    {
            obstacleSpawnIndex2 = Random.Range(4, 9);
            if (obstacleSpawnIndex2 != obstacleSpawnIndex)
            {
                spawnPoint2 = transform.GetChild(obstacleSpawnIndex2);
                Instantiate(ObstaclePrefabs[RandomObs], spawnPoint2.position, Quaternion.identity, transform);
            }       
    }

    void SpawnThirdObstacles()
    {
            obstacleSpawnIndex3 = Random.Range(4, 9);
            if (obstacleSpawnIndex3 != obstacleSpawnIndex && obstacleSpawnIndex3 != obstacleSpawnIndex2)
            {
                spawnPoint3 = transform.GetChild(obstacleSpawnIndex3);
                Instantiate(ObstaclePrefabs[RandomObs], spawnPoint3.position, Quaternion.identity, transform);
            }   
    }

    void SpawnFourthObstacles()
    {
        obstacleSpawnIndex4 = Random.Range(4, 9);
        if (obstacleSpawnIndex4 != obstacleSpawnIndex && obstacleSpawnIndex4 != obstacleSpawnIndex2 && obstacleSpawnIndex4 != obstacleSpawnIndex3)
        {
            spawnPoint4 = transform.GetChild(obstacleSpawnIndex4);
            Instantiate(ObstaclePrefabs[RandomObs], spawnPoint4.position, Quaternion.identity, transform);
        }
    }

    void SpawnFifthObstacles()
    {
        obstacleSpawnIndex5 = Random.Range(4, 9);
        if (obstacleSpawnIndex5 != obstacleSpawnIndex && obstacleSpawnIndex5 != obstacleSpawnIndex2 && obstacleSpawnIndex5 != obstacleSpawnIndex3 && obstacleSpawnIndex5 != obstacleSpawnIndex4)
        {
            spawnPoint5 = transform.GetChild(obstacleSpawnIndex5);
            Instantiate(ObstaclePrefabs[RandomObs], spawnPoint5.position, Quaternion.identity, transform);
        }
    }
}
