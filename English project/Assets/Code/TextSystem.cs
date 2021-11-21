using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextSystem : MonoBehaviour
{
    private Text Text;

    void Start()
    {
        Text = GetComponent<Text>();
    }

    public static TextSystem Create(Vector2 size, Vector2 position, Vector2? scale = null, FontData fontData = null, Color? color = null)
    {
        var go = Instantiate(AssetBank.TextField, GameObject.Find("Canvas").transform);
        var transform = go.GetComponent<RectTransform>();
        var system = go.GetComponent<TextSystem>();
        var text = go.GetComponent<Text>();

        if (scale != null) transform.localScale = scale.Value;
        transform.localPosition = position;
        transform.sizeDelta = size;

        if (fontData != null)
        {
            if (fontData.font != null) text.font = fontData.font;
            if (fontData.fontSize != 0) text.fontSize = fontData.fontSize;
            text.fontStyle = fontData.fontStyle;
        }
        if (color != null) text.color = color.Value;
        return system;
    }

    public IEnumerator AnimateText(string str, float delay)
    {
        Text.text = "";
        if (delay > 0)
            foreach (char c in str)
            {
                Text.text += c;
                yield return new WaitForSeconds(delay);
            }
        else
        {
            Text.text = str;
            yield return null;
        }
    }

    public IEnumerator AnimateTextOut(float delay)
    {
        for (int i = 0; i < Text.text.Length;)
        {
            Text.text = Text.text.Remove(0, 1);
            yield return new WaitForSeconds(delay);
        }
    }
}
