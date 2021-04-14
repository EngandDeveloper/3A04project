using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int x, y, z;
    private Transform propTransform;
    Collider propCollider;
    public int propSpeed;
    void Start()
    {
        StartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Die();

    }

    private void StartPosition()
    {
        y = 8;
        z = 0;
        propTransform = transform;
        propTransform.position = new Vector3(Random.Range(-8, 8), y, z);
        propSpeed = 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Spaceship.shipLevel = 2;
        }

    }
    void Die()
    {
        if (propTransform.position.y <= -10.7)
        {
            Destroy(this.gameObject);
        }
    }
    void Movement()
    {
        propTransform.Translate(-Vector3.up * propSpeed * Time.deltaTime);
    }
}
