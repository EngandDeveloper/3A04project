using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public int shipSpeed;
    public int rotSpeed;
    public float boundary;
    public static int health;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    Quaternion rot;
    public GameObject laserPrefab;
    public static int shipLevel;
    float timer = 0f;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        SetSpeed();
        StartPosition();
        SetBoundary();
        SetHealth();
        SetShipLevel();
        SetRend();

    }

    // Update is called once per frame
    void Update()
    {
        Movenent();
        Die();
        Fire();
        spwan();
    }
    private void SetSpeed()
    {
        shipSpeed = 10;
        rotSpeed = 180;
    }

    private void StartPosition()
    {
        transform.position = new Vector3(0, -4.3f, 0);
    }

    private void SetBoundary()
    {
        boundary = 0.5f;
    }
    private void SetHealth()
    {
        health = 3;
    }
    private void SetShipLevel()
    {
        shipLevel = 1;
    }

    private void SetRend()
    {
        rend = GetComponent<Renderer>();
    }

    public static int GetShipLevel()
    {
        return shipLevel;
    }

    private void Movenent()
    {
        //rotation
        rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z += -Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //recreate the quaternion
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //movement
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * shipSpeed * Time.deltaTime, 0);
        Vector3 pos = transform.position;
        pos += rot * velocity;
        transform.position = pos;

        //boundary
        float maxY = Camera.main.orthographicSize;
        if (transform.position.y + boundary > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY - boundary, transform.position.z);
        }
        else if (transform.position.y - boundary < -maxY)
        {
            transform.position = new Vector3(transform.position.x, -maxY + boundary, transform.position.z);
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float maxX = maxY * screenRatio;
        if (transform.position.x + boundary > maxX)
        {
            transform.position = new Vector3(maxX - boundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x - boundary < -maxX)
        {
            transform.position = new Vector3(-maxX + boundary, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "laser2")
        {
            health -= 1;
            shipLevel = 1;
            rend.enabled = false;
            timer = Time.time; //from the start of the game up to now
            Die();
        }

    }

    void spwan()
    {
        if (Time.time - timer > 0.5)
        {
            rend.enabled = true;
        }
    }
    private void Die()
    {
        if(health == 0 || SpaceShooterController.gameLevel== SpaceShooterController.EndLevel())
        {
            Destroy(this.gameObject);
        }    
    }
    private void Fire()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetKeyDown("space") && cooldownTimer < 0)
        {
            if(GetShipLevel() != 2)
            {
                //shoot
                Vector3 startPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Instantiate(laserPrefab, startPoint, transform.rotation);
                cooldownTimer = fireDelay;
            }
            else
            {
                //shoot
                Vector3 startPoint1 = new Vector3(transform.position.x - 0.25f, transform.position.y, transform.position.z);
                Vector3 startPoint2 = new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z);
                Instantiate(laserPrefab, startPoint1, transform.rotation);
                cooldownTimer = fireDelay;
                Instantiate(laserPrefab, startPoint2, transform.rotation);
                cooldownTimer = fireDelay;
            }
        }        
    }

    


}
