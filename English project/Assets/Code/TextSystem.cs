using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSystem : MonoBehaviour
{
    private Text Text;

    void Start()
    {
        Text = GetComponent<Text>();
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
}
