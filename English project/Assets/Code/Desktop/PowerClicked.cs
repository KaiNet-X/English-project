using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerClicked : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Home");
    }
}
