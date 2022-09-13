using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    PlayerMovement playerMovement;
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            playerMovement.Hitsound.Play();
            playerMovement.BoostAmount -= 1;
            playerMovement.BoostEnergy -= 20f;
            playerMovement.speed = 10;
            playerMovement.horizontalMultiplier = 4f;
            Debug.Log("boost -1");
            playerMovement.die();
            Destroy(this.gameObject);
            playerMovement.PlayerCam.fieldOfView = 60;
            GameObject firework = Instantiate(Explosion, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            playerMovement.Hitsound.Play();
            playerMovement.BoostAmount -= 1;
            playerMovement.speed = 10;
            playerMovement.BoostEnergy -= 20f;
            playerMovement.horizontalMultiplier = 4f;
            playerMovement.die();
            Destroy(this.gameObject);
            playerMovement.PlayerCam.fieldOfView = 60;
            GameObject firework = Instantiate(Explosion, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
