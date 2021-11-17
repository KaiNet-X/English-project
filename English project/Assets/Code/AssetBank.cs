using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBank : MonoBehaviour
{
    public static GameObject FadeEffect;
    public static GameObject SpeechBubble;
    public static GameObject TextField;
    public static GameObject E;

    public GameObject fadeEffect;
    public GameObject speechButton;
    public GameObject text;
    public GameObject e;

    public void Awake()
    {
        FadeEffect = fadeEffect;
        SpeechBubble = speechButton;
        TextField = text;
        E = e;
    }
}
