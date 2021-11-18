using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboBulletController : ComboInstanceController
{
    public GameObject bullet;
    public int bulletCount;

    public override void OnConsume()
    {
        playerShip = FindObjectOfType<ShipController>();

        playerShip.bullet = bullet;
        playerShip.bulletCount = bulletCount;
    }
}
