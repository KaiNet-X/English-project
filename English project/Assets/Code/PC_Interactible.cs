using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PC_Interactible : MonoBehaviour
{
    private GameObject obj;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled)
        {
            obj = Instantiate(AssetBank.E, GameObject.Find("Canvas").transform);
            obj.transform.position = transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E)) SceneManager.LoadScene("Desktop");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (obj != null)
        {
            Destroy(obj);
            obj = null;
        }
    }
}
