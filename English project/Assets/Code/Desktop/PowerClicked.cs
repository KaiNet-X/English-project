using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerClicked : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Interview1");
    }
}
