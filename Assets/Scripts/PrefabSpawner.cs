using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabArea;
    public GameObject[] asteroids;
    public GameObject[] combo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AsteroidSpawnRoutine());
        StartCoroutine(ComboSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator AsteroidSpawnRoutine()
    {
        float bound = prefabArea.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float x_pos = Random.Range(-bound, bound);
        float y_pos = prefabArea.transform.position.y;
        Vector3 position = new Vector3(x_pos, y_pos, 0);

        yield return new WaitForSeconds(2f);

        int asteroid_index = Random.Range(0, asteroids.Length);

        Instantiate(asteroids[asteroid_index], position, Quaternion.identity);

        StartCoroutine(AsteroidSpawnRoutine());
    }

    IEnumerator ComboSpawnRoutine()
    {
        float bound = prefabArea.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float x_pos = Random.Range(-bound, bound);
        float y_pos = prefabArea.transform.position.y;
        Vector3 position = new Vector3(x_pos, y_pos, 0);

        yield return new WaitForSeconds(15f);

        int combo_index = Random.Range(0, combo.Length);

        Instantiate(combo[combo_index], position, Quaternion.identity);

        StartCoroutine(ComboSpawnRoutine());
    }
}
