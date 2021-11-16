using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    private GameObject text;
    private RectTransform rectTransform;

    public GameObject Owner;
    public Vector2 Size;
    public Vector2 TextSize;
    public Vector2 Offset;
    public string Text;
    public float Delay;

    void Start()
    {
        text = transform.GetChild(0).gameObject;
        rectTransform = GetComponent<RectTransform>();
        GetComponent<Image>().enabled = false;
    }

    public void Init()
    {
        rectTransform.sizeDelta = Size;
        text.GetComponent<RectTransform>().sizeDelta = TextSize;
        GetComponent<Image>().enabled = true;
        StartCoroutine(text.GetComponent<TextSystem>().AnimateText(Text, Delay));
    }

    void Update()
    {
        if (Owner != null) rectTransform.position = Owner.transform.position + new Vector3(Offset.x, Offset.y);
    }
}
