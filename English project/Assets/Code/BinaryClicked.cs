using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BinaryClicked : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Game1");
        //StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        var fade = Instantiate(AssetBank.FadeEffect);
        var renderer = fade.GetComponent<SpriteRenderer>();

        renderer.color = new Color(0, 0, 0, 0);
        StartCoroutine(Animations.FadeSprite(renderer, new Color(0, 0, 0, 1), 3));

        var ts = Instantiate(AssetBank.TextField, GameObject.Find("Canvas").transform);
        var system = ts.GetComponent<TextSystem>();
        var rect = ts.GetComponent<RectTransform>();
        var txt = ts.GetComponent<Text>();

        ts.transform.position = new Vector2(0, 4);
        rect.sizeDelta = new Vector2(2250, 90);
        txt.color = new Color(1, 1, 1);
        txt.fontSize = 40;
        txt.fontStyle = FontStyle.Bold;

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(system.AnimateText("The goal is to fix as many bugs (click the 2s) without deleting good code (1s and 0s) as possible in a short time frame.", .02f));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(system.AnimateTextOut(.02f));
    }
}
