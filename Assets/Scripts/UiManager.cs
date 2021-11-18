using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text heartText;
    public Text gameOverText;
    public Text bulletCountText;

    public EventSystemManager eventSystem;

    public ShipController player;

    void Start()
    {
        eventSystem.OnAsteroidCollisionEnter.AddListener(UpdateHeartText);
        eventSystem.OnShipVanishedEnter.AddListener(GetGameOverText);
        eventSystem.OnTriggerFireEnter.AddListener(UpdateBulletCountText);
    }

    private void UpdateBulletCountText()
    {
        string[] tokens = bulletCountText.text.Split(' ');
        int newKeyValue = player.bulletCount;
        bulletCountText.text = tokens[0] + ' ' + tokens[1] + ' ' + newKeyValue;
    }

    public void UpdateHeartText()
    {
        string[] tokens = heartText.text.Split(' ');
        int newKeyValue = player.heart;
        heartText.text = tokens[0] + ' ' + tokens[1] + ' ' + newKeyValue;
    }

    public void GetGameOverText()
    {
        var time = ((int)Time.realtimeSinceStartup).ToString();
        gameOverText.text = "Record: " + time;
    }
}
