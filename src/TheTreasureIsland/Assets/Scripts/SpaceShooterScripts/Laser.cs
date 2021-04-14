using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    float laserSpeed;
    public float boundary;

    // Start is called before the first frame update
    void Start()
    {
        SetLaserSpeed();
        SetBoundary();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Die();
    }

    private void SetLaserSpeed()
    {
        laserSpeed = 15f;
    }
    private void SetBoundary()
    {
        boundary = 0.5f;
    }

    private float GetBoundary()
    {
        return boundary;
    }

    private float GetLaserSpeed()
    {
        return laserSpeed;
    }


    private void Movement()
    {
        Vector3 velocity = new Vector3(0, GetLaserSpeed() * Time.deltaTime, 0);
        Vector3 pos = transform.position;
        pos +=  transform.rotation* velocity;
        transform.position = pos;
    }
    private void Die()
    {
        float maxY = Camera.main.orthographicSize;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float cameraWidth = maxY * screenRatio;
        if (transform.position.y + GetBoundary() > maxY || transform.position.y - GetBoundary() < -maxY || transform.position.x + GetBoundary() > cameraWidth || transform.position.x - GetBoundary() < -cameraWidth)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }


}
