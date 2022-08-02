using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float Maxspeed = 30;
    public Transform bulletSpawnPoint;
    public Rigidbody rb;
    public GameObject bullet;

    public float distance = 0f;
    public int Count = 0;

    public int BoostAmount = 3;
    bool alive = true;

    float horizontalInput;
    public float horizontalMultiplier = 1.2f;

    private void Start()
    {
        distance = 1800;
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        distance += speed;

        if(distance >= 2000)
        {
            Count += 1;
            distance = 0;
            Debug.Log("" + Count);
        }

        if (transform.position.y < -2)
        {
            BoostAmount = 0;
            die();
        }

        if (Input.GetMouseButtonDown(0))
        {
            shootBullet();
        }

        if (Input.GetKeyDown("space"))
        {
            if(speed < Maxspeed)
            {
                Boost();              
            }
        }

        if(speed >= Maxspeed)
        {
            speed = Maxspeed;
        }
    }

    public void die()
    {
        if(BoostAmount <= 0f)
        {
            alive = false;
            Invoke("Restart", 2);
        }
    }

    public void shootBullet()
    {
        GameObject b = Instantiate(bullet);
        b.transform.position = bulletSpawnPoint.transform.position;
        Destroy(b, 0.5f);
    } 

    public void Boost()
    {
        speed += 5;
        horizontalMultiplier += 0.05f;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}