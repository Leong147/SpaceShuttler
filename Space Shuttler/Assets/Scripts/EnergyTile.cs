using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    public GameObject CoinPrefab;
    Transform spawnPoint;
    Transform spawnPoint2;
    int obstacleSpawnIndex;
    int EnergySpawnIndex;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
        SpawnEnergyPoint();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacles()
    {
        obstacleSpawnIndex = Random.Range(4,8);
        spawnPoint = transform.GetChild(obstacleSpawnIndex);

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnEnergyPoint()
    {
            EnergySpawnIndex = Random.Range(4, 8);
            if (EnergySpawnIndex != obstacleSpawnIndex)
            {
                spawnPoint2 = transform.GetChild(EnergySpawnIndex);
                Instantiate(CoinPrefab, spawnPoint2.position, Quaternion.identity, transform);
            }       
    }
}
