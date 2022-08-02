using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public PlayerMovement playermovement;
    public GameObject groundTile;
    public GameObject groundTile1;
    public GameObject groundTile2;

    public GameObject EnergyTile;

    Vector3 nextSpawnPoint;
    int GSCount = 0;

    public void SpawnTile()
    {
        if(GSCount == 0)
        {
            GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }

        else if(GSCount >= 0 && GSCount < 200 && playermovement.EnergyPoint != true)
            {
                GameObject temp = Instantiate(groundTile1, nextSpawnPoint, Quaternion.identity);
                nextSpawnPoint = temp.transform.GetChild(1).transform.position;
            }

        else if (GSCount >= 0 && GSCount < 200 && playermovement.EnergyPoint == true)
        {
            GameObject temp = Instantiate(EnergyTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
            playermovement.EnergyPoint = false;
            Debug.Log("Spawn Energy Point");
        }

        else if (GSCount >= 200 && playermovement.EnergyPoint != true)
        {
            GameObject temp = Instantiate(groundTile2, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }

        else if (GSCount >= 200 && playermovement.EnergyPoint == true)
        {
            GameObject temp = Instantiate(EnergyTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
            playermovement.EnergyPoint = false;
            Debug.Log("Spawn Energy Point");
        }
    }

    void Start()
    {
        for(int i=0; i < 10; i++)
        {
            SpawnTile();
        }
    }

    private void Update()
    {
        GSCount = playermovement.Count;
    }
}
