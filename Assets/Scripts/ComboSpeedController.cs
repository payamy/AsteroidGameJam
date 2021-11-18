using UnityEngine;
using System.Collections;

public class ComboSpeedController : ComboInstanceController
{
    public override void OnConsume()
    {
        playerShip = FindObjectOfType<ShipController>();

        playerShip.speed = 0.2f;
    }
}
