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
    Vector3 nextSpawnPoint;
    int GSCount = 0;

    public void SpawnTile()
    {
        if(GSCount == 0)
        {
            GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }
        else if(GSCount >= 0 && GSCount < 50)
            {
                GameObject temp = Instantiate(groundTile1, nextSpawnPoint, Quaternion.identity);
                nextSpawnPoint = temp.transform.GetChild(1).transform.position;
            }
        else if (GSCount >= 50)
        {
            GameObject temp = Instantiate(groundTile2, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }
    }

    void Start()
    {
        for(int i=0; i < 15; i++)
        {
            SpawnTile();
        }
    }

    private void Update()
    {
        GSCount = playermovement.Count;
    }
}
