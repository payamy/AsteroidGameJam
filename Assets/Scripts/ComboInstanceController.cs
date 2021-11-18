using UnityEngine;
using System.Collections;

public abstract class ComboInstanceController : MonoBehaviour
{
    protected ShipController playerShip;

    public abstract void OnConsume();

    private void Update()
    {
        transform.position -= new Vector3(0, 2.5f, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death Zone")
        {
            Destroy(this.gameObject);
        }
    }
}
