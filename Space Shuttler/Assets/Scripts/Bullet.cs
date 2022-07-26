using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioSource Hitsound;
    public float speed = 100f;
    public Rigidbody rb;
    private Collider other;
    public GameObject Explosion;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0, 0, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "obstacle")
        {
            Hitsound.Play();
            GameObject firework = Instantiate(Explosion, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
