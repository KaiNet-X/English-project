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

    public Text TextBox;

    void Start()
    {
        text = transform.GetChild(0).gameObject;
        rectTransform = GetComponent<RectTransform>();
        GetComponent<Image>().enabled = false;
        TextBox = text.GetComponent<Text>();
    }

    void Update()
    {
        if (Owner != null) rectTransform.position = Owner.transform.position + new Vector3(Offset.x, Offset.y);
    }

    public static SpeechBubble Create(string text, float delay, Vector2 outerSize, Vector2 innerSize, Vector2 offset, GameObject owner = null)
    {
        var go = Instantiate(AssetBank.SpeechBubble, GameObject.Find("Canvas").transform);
        var bubble = go.GetComponent<SpeechBubble>();

        bubble.Text = text;
        bubble.Delay = delay;
        bubble.Size = outerSize;
        bubble.TextSize = innerSize;
        bubble.Offset = offset;
        bubble.Owner = owner;

        return bubble;
    }

    public void UpdateVisuals()
    {
        rectTransform.position = Owner.transform.position + new Vector3(Offset.x, Offset.y);
        rectTransform.sizeDelta = Size;
        text.GetComponent<RectTransform>().sizeDelta = TextSize;
        GetComponent<Image>().enabled = true;
        StartCoroutine(text.GetComponent<TextSystem>().AnimateText(Text, Delay));
    }
}
