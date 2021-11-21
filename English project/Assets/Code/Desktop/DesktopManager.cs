using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DesktopManager : MonoBehaviour
{
    private Text HP;
    public static bool Interview1Load = false;
    public static bool Interview2Load = false;

    void Start()
    {
        //HP = GameObject.Find("HackerPoints").GetComponent<Text>();
    }

    void Update()
    {
        //HP.text = $"Hacker points: {AssetBank.HackerPoints}";
    }

    public void Interview1()
    {
        Interview1Load = true;
        SceneManager.LoadScene("Interview1");
    }
    public void Interview2()
    {
        Interview2Load = true;
        SceneManager.LoadScene("Interview2");
    }
}
