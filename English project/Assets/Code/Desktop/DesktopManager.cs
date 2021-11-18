using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopManager : MonoBehaviour
{
    private Text HP;

    void Start()
    {
        HP = GameObject.Find("HackerPoints").GetComponent<Text>();
    }

    void Update()
    {
        HP.text = $"Hacker points: {AssetBank.HackerPoints}";
    }
}
