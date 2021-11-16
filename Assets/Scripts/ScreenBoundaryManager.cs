using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaryManager
{
    private Vector2 screenBoundaries;

    public void keepInBoundaries(GameObject gameObject)
    {
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        float objectWidth = gameObject.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float objectHeight = gameObject.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        Vector3 viewPos = gameObject.transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBoundaries.x + objectWidth, screenBoundaries.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBoundaries.y + objectHeight, screenBoundaries.y - objectHeight);

        gameObject.transform.position = viewPos;
    }
}
