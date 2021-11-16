using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text heartText;
    public Text gameOverText;

    public EventSystemManager eventSystem;

    public ShipController player;

    void Start()
    {
        eventSystem.OnAsteroidCollisionEnter.AddListener(UpdateHeartText);
        eventSystem.OnShipVanishedEnter.AddListener(GetGameOverText);
    }

    public void UpdateHeartText()
    {
        string[] tokens = heartText.text.Split(' ');
        int newKeyValue = player.heart;
        heartText.text = tokens[0] + ' ' + tokens[1] + ' ' + newKeyValue;
    }

    public void GetGameOverText()
    {
        gameOverText.text = "Game Over";
    }
}
