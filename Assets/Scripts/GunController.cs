using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private ShipController playerShip;

    public EventSystemManager eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = FindObjectOfType<ShipController>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerShip.bullet)
            {
                GameObject bullet = Instantiate(playerShip.bullet);
                bullet.transform.position = transform.position;

                playerShip.bulletCount--;

                eventSystem.OnTriggerFireEnter.Invoke();
            }
        }
    }
}
