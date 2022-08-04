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
    public Camera PlayerCam;
    bool AddFOV;
    public float CamValue = 0;

    public float distance = 0f;
    public int Count = 0;

    public int BoostAmount = 3;
    bool alive = true;

    public Text score;
    public Text bulletText;
    public Text boostEnergyText;
    public Text lifeText;

    float horizontalInput;
    public float horizontalMultiplier = 4f;
    float MaxhorizontalMultiplier = 6f;

    public int BulletAmount;
    public int MaxBulletAmout = 8;
    float bulletCooldown = 0;

    public GameObject Energy;

    bool TestMax;

    private void Start()
    {
        Count = 0;
        distance = 5.99f;
        BulletAmount = 5;
        Time.timeScale = 1;
        EnergyPoint = true;
        PlayerCam.fieldOfView = 60;
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        //below were from update
        //BoostEnergy -= 1.15f * Time.deltaTime;
        distance += speed * Time.deltaTime;
        BoostEnergy = 100f;

        if (BulletAmount < MaxBulletAmout)
        {
            bulletCooldown += Time.deltaTime;
        }

        if (AddFOV == true)
        {
            IncreaseCamValue();
            PlayerCam.fieldOfView += CamValue;

            if (CamValue > 0.33)
            {
                CamValue = 0;
                AddFOV = false;
            }
        }

        ///
        ///test final
        ///

        if (Input.GetKeyDown("m"))
        {
            TestMax = true;
            Debug.Log("Limit Break");
        }

        if (TestMax == true || Count >= 1500)
        {
            Maxspeed = 35;
            speed = Maxspeed;
            horizontalMultiplier = 5.5f;
            IncreaseCamValue();
            PlayerCam.fieldOfView += CamValue;

            if(PlayerCam.fieldOfView > 75)
            {
                PlayerCam.fieldOfView = 75;
            }

            if (bulletCooldown >= 1)
            {
                BulletAmount += 1;
                bulletCooldown = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Count.ToString();
        bulletText.text = BulletAmount.ToString();
        boostEnergyText.text = BoostEnergy.ToString();
        lifeText.text = BoostAmount.ToString();
        //BoostEnergy -= 1.25f * Time.deltaTime;

        horizontalInput = Input.GetAxis("Horizontal");

        //distance += speed;

        if(distance >= 6)
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
        //if (BulletAmount < MaxBulletAmout)
        //{
        //    bulletCooldown += Time.deltaTime;
        //}

        if (Count < 1500)
        {
            if (bulletCooldown >= 5)
            {
                BulletAmount += 1;
                bulletCooldown = 0;
            }
        }
        else if (Count >= 1500)
        {
            if (bulletCooldown >= 1.5)
            {
                BulletAmount += 1;
                bulletCooldown = 0;
            }
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
        if (Count > 0 && Count <= 250 && Count % 25 == 0)
        {
            EnergyPoint = true;
        }

        if (Count >= 250 && Count <= 750 && Count % 30 == 0)
        {
            EnergyPoint = true;
        }

        if (Count >= 750 && Count % 50 == 0)
        {
            EnergyPoint = true;
        }

        if (Count >= 1500 && Count % 65 == 0)
        {
            EnergyPoint = true;
        }

        if (BoostAmount <= 0f)
        {
            die();
        }

        if(PlayerCam.fieldOfView > 72)
        {
            PlayerCam.fieldOfView = 72;
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
            Destroy(b, 2f);
        }
        
    } 

    public void Boost()
    {
        speed += 5;
        horizontalMultiplier += 0.5f;
        AddFOV = true;
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
            horizontalMultiplier += 0.5f;
            Destroy(other.gameObject);
            AddFOV = true;
            BoostEnergy += 30f;
        }
    }

    void IncreaseCamValue()
    {
        CamValue += Time.fixedDeltaTime;
    }

}