using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            playerMovement.BoostAmount -= 1;
            playerMovement.BoostEnergy -= 20f;
            playerMovement.speed = 10;
            playerMovement.horizontalMultiplier = 3.8f;
            Debug.Log("boost -1");
            playerMovement.die();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            playerMovement.BoostAmount -= 1;
            playerMovement.speed = 10;
            playerMovement.BoostEnergy -= 20f;
            playerMovement.horizontalMultiplier = 3.8f;
            Debug.Log("boost -1");
            playerMovement.die();
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
