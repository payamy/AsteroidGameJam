using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    public int heart;

    public int bulletCount;
    public GameObject bullet;

    public EventSystemManager eventSystem;

    private ScreenBoundaryManager boundaryManager;

    // Start is called before the first frame update
    void Start()
    {
        boundaryManager = new ScreenBoundaryManager();

        eventSystem.OnAsteroidCollisionEnter.Invoke();
        eventSystem.OnTriggerFireEnter.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0) * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1, 0) * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * speed;
        }

        // keep the spaceship in screen bounds
        boundaryManager.keepInBoundaries(this.gameObject);

        // check if spaceship still have bullets
        if (bulletCount <= 0)
        {
            bulletCount = 0;
            bullet = null;
        }

        if (speed > 0.1)
        {
            speed -= 0.00015f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            AsteroidManager asteroid = collision.gameObject.GetComponent<AsteroidManager>();
            heart -= asteroid.config.power;

            // destroy the asteroid
            Destroy(collision.gameObject);

            // check if spaceship is destroyed
            if (heart <= 0)
            {
                heart = 0;
                eventSystem.OnShipVanishedEnter.Invoke();
                Destroy(this.gameObject);
            }

            // update heart count on Ui
            eventSystem.OnAsteroidCollisionEnter.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Combo")
        {
            ComboInstanceController comboController = collision.gameObject.GetComponent<ComboInstanceController>();
            comboController.OnConsume();

            Destroy(collision.gameObject);

            if (comboController.GetType().Name == "ComboBulletController")
            {
                eventSystem.OnTriggerFireEnter.Invoke();
            }
        }
    }
}
