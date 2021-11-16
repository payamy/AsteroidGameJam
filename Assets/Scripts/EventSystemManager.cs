using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemManager : MonoBehaviour
{
    public UnityEvent OnAsteroidCollisionEnter;
    public UnityEvent OnShipVanishedEnter;

    private void Awake()
    {
        OnAsteroidCollisionEnter = new UnityEvent();
        OnShipVanishedEnter = new UnityEvent();
    }
}
