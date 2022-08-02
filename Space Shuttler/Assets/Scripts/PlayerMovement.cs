using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float Maxspeed = 30;
    public Transform bulletSpawnPoint;
    public Rigidbody rb;
    public GameObject bullet;
    public bool EnergyPoint;
    public float BoostEnergy = 100f;
    float MaxBoostEnergy = 100f;

    public float distance = 0f;
    public int Count = 0;

    public int BoostAmount = 3;
    bool alive = true;

    public Text score;
    public Text bulletText;
    public Text boostEnergyText;

    float horizontalInput;
    public float horizontalMultiplier = 1.2f;
    float MaxhorizontalMultiplier = 1.5f;

    public int BulletAmount;
    public int MaxBulletAmout = 8;
    float bulletCooldown = 0;

    public GameObject Energy;

    private void Start()
    {
        Count = 0;
        distance = 1950;
        BulletAmount = 5;
        Time.timeScale = 1;
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
        score.text = Count.ToString();
        bulletText.text = BulletAmount.ToString();
        boostEnergyText.text = BoostEnergy.ToString();
        BoostEnergy -= 1.25f * Time.deltaTime;

        horizontalInput = Input.GetAxis("Horizontal");

        distance += speed;

        if(distance >= 2000)
        {
            Count += 1;
            distance = 0;
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

        if (speed >= Maxspeed)
        {
            speed = Maxspeed;
        }

        if (horizontalMultiplier >= MaxhorizontalMultiplier)
        {
            horizontalMultiplier = MaxhorizontalMultiplier;
        }

        //Charging bullet
        if (BulletAmount < MaxBulletAmout)
        {
            bulletCooldown += Time.deltaTime;
        }

        if(bulletCooldown >= 5)
        {
            BulletAmount += 1;
            bulletCooldown = 0;
        }

        if(BulletAmount >= MaxBulletAmout)
        {
            BulletAmount = MaxBulletAmout;
        }

        if(BoostEnergy >= MaxBoostEnergy)
        {
            BoostEnergy = MaxBoostEnergy;
        }

        if(BoostEnergy <= 0)
        {
            BoostEnergy = 0;
            BoostAmount = 0;
            die();
        }

        //Debug test speed up
        if (Input.GetKeyDown("space"))
        {
            if(speed < Maxspeed)
            {
                Boost();              
            }
        }

        //Set for Spawning Energy Point Tile
        if (Count > 0 && Count <= 200 && Count % 25 == 0)
        {
            EnergyPoint = true;
        }

        if (Count > 200 && Count <= 500 && Count % 30 == 0)
        {
            EnergyPoint = true;
        }

        if (Count > 500 && Count % 50 == 0)
        {
            EnergyPoint = true;
        }
    }

    public void die()
    {
        if(BoostAmount <= 0f)
        {
            BoostEnergy = 0f;
            speed = 0;
            alive = false;
            Invoke("Restart", 2);
        }
    }

    public void shootBullet()
    {
        if(BulletAmount > 0)
        {
            GameObject b = Instantiate(bullet);
            b.transform.position = bulletSpawnPoint.transform.position;
            BulletAmount -= 1;
            Destroy(b, 0.5f);
        }
        
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "energypoint")
        {
            BulletAmount += 1;
            speed += 5;
            horizontalMultiplier += 0.05f;
            Destroy(other.gameObject);
            BoostEnergy += 30f;
        }
    }
}