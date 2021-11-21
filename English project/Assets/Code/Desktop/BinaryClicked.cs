using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BinaryClicked : MonoBehaviour
{
    public static bool FirstTime = true;

    private void OnMouseDown()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        var fade = Instantiate(AssetBank.FadeEffect);
        var renderer = fade.GetComponent<SpriteRenderer>();
        fade.transform.position += new Vector3(0, 0, -1);
        renderer.color = new Color(0, 0, 0, 0);
        renderer.sortingOrder = 3;
        StartCoroutine(Animations.FadeSprite(renderer, new Color(0, 0, 0, 1), 3));

        var ts = Instantiate(AssetBank.TextField, GameObject.Find("Canvas").transform);
        var system = ts.GetComponent<TextSystem>();
        var rect = ts.GetComponent<RectTransform>();
        var txt = ts.GetComponent<Text>();

        ts.transform.position = new Vector3(0, 3.5f, -2);
        rect.sizeDelta = new Vector2(1125, 180);
        txt.color = new Color(1, 1, 1);
        txt.fontSize = 40;
        txt.fontStyle = FontStyle.Bold;

        yield return new WaitForSeconds(2.5f);

        if (!FirstTime)
        {
            SceneManager.LoadScene("Game1");
            yield break;
        }
        StartCoroutine(system.AnimateText("The goal is to fix as many bugs (click the 2s) without deleting good code (1s and 0s) as possible in a short time frame.", .02f));
        yield return new WaitForSeconds(4.5f);
        StartCoroutine(system.AnimateTextOut(.005f));
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Game1");
        FirstTime = false;
    }
}
