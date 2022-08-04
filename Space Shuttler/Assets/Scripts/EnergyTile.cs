using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject[] ObstaclePrefabs;
    public GameObject CoinPrefab;
    Transform spawnPoint;
    Transform spawnPoint2;
    int obstacleSpawnIndex;
    int EnergySpawnIndex;

    int RandomObs;

    // Start is called before the first frame update
    void Start()
    {
        RandomObs = Random.Range(0, ObstaclePrefabs.Length);

        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnEnergyPoint();
        SpawnObstacles();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnergyPoint()
    {
        EnergySpawnIndex = Random.Range(4,9);
        spawnPoint = transform.GetChild(EnergySpawnIndex);

        Instantiate(CoinPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnObstacles()
    {
            obstacleSpawnIndex = Random.Range(4, 9);
            if (obstacleSpawnIndex != EnergySpawnIndex)
            {
                spawnPoint2 = transform.GetChild(obstacleSpawnIndex);
                Instantiate(ObstaclePrefabs[RandomObs], spawnPoint2.position, Quaternion.identity, transform);
            }       
    }
}
