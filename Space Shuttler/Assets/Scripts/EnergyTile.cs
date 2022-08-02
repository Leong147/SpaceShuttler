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
        SpawnEnergyPoint();
        SpawnObstacles();
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
                Instantiate(obstaclePrefab, spawnPoint2.position, Quaternion.identity, transform);
            }       
    }
}
