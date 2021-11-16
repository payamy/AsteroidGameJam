using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AsteroidConfig", menuName = "Config Files/AsteroidConfig")]
public class AsteroidConfig : ScriptableObject
{
    public float speed;
    public int power;
}
