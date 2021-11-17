using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryValue : MonoBehaviour
{
    public static int score;
    public int value;

    private void OnMouseDown()
    {
        if (value == 2)
        {
            score += 5;
            Instantiate(GameObject.Find("Manager").GetComponent<Game1Manager>().G0).transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
        else
        {
            score -= 3;
            Destroy(gameObject);
        }
    }
}
