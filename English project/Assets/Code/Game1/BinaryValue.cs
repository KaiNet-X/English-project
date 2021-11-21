using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BinaryValue : MonoBehaviour
{
    public int Value;

    private void OnMouseDown()
    {
        if (Value == 2)
        {
            Game1Manager.Score += 5;
            Game1Manager.Errors--;
            if (SceneManager.GetActiveScene().name == "Game1")
                Instantiate(AssetBank.Zero).transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
        else
        {
            Game1Manager.Score -= 3;
            Destroy(gameObject);
        }
    }
}
