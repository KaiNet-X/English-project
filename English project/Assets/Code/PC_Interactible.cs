using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PC_Interactible : MonoBehaviour
{
    private GameObject obj;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (obj == null)
        {
            obj = Instantiate(AssetBank.E, GameObject.Find("Canvas").transform);
            obj.transform.position = transform.position;
        }
        if (Input.GetKey(KeyCode.E))
            SceneManager.LoadScene("Desktop");
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
