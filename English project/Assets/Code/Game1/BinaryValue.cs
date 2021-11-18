using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryValue : MonoBehaviour
{
    public int Value;

    private void OnMouseDown()
    {
        if (Value == 2)
        {
            Game1Manager.Score += 5;
            Game1Manager.Errors--;
            try
            {
                Instantiate(GameObject.Find("Manager").GetComponent<Game1Manager>().G0).transform.position = gameObject.transform.position;
            }
            catch
            {

            }
            Destroy(gameObject);
        }
        else
        {
            Game1Manager.Score -= 3;
            Destroy(gameObject);
        }
    }
}
