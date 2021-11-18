using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBank : MonoBehaviour
{
    public static GameObject FadeEffect;
    public static GameObject SpeechBubble;
    public static GameObject TextField;
    public static GameObject E;
    public static GameObject LineStart;
    public static GameObject Zero;
    public static GameObject One;
    public static GameObject Two;

    public static AudioClip KaiTrack;
    public static AudioClip BossBattle;
    public static AudioClip HeartBeat;

    public GameObject fadeEffect;
    public GameObject speechButton;
    public GameObject text;
    public GameObject e;
    public GameObject lineStart;
    public GameObject zero;
    public GameObject one;
    public GameObject two;


    public AudioClip kaiTrack;
    public AudioClip bossBattle;
    public AudioClip heartBeat;

    public static int HackerPoints = 0;

    public void Awake()
    {
        FadeEffect = fadeEffect;
        SpeechBubble = speechButton;
        TextField = text;
        E = e;

        LineStart = lineStart;
        Zero = zero;
        One = one;
        Two = two;

        KaiTrack = kaiTrack;
        BossBattle = bossBattle;
        HeartBeat = heartBeat;
    }
}
