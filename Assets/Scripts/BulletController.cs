using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int damage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1, 0) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            AsteroidManager asteroid = collision.gameObject.GetComponent<AsteroidManager>();

            // reduce asteroid stamina
            asteroid.stamina -= damage;

            // check if asteroid is fully vanished
            if (asteroid.stamina <= 0)
            {
                Destroy(collision.gameObject);
            }

            // destory the bullet
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death Zone")
        {
            Destroy(this.gameObject);
        }
    }
}
