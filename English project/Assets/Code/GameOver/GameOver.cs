using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(animate());
    }

    private IEnumerator animate()
    {
        foreach (var source in FindObjectsOfType<AudioSource>()) 
            if (source.gameObject.name != "FadeEffect") 
                source.Stop();

        var txt = TextSystem.Create(
        new Vector2(600, 100),
        new Vector2(0, 0),
        new Vector2(.5f, .5f),
        new FontData
        {
            fontStyle = FontStyle.Bold,
            fontSize = 55
        },
        new Color(1f, 1f, 0));

        var fe = GameObject.Find("FadeEffect").GetComponent<SpriteRenderer>();
        fe.gameObject.GetComponent<AudioSource>().volume = 1.5f;
        yield return null;

        for (int i = 0; i < 10; i++)
        {
            StartCoroutine(txt.AnimateText("ERROR: Game over", .1f));
            StartCoroutine(Animations.FadeSprite(fe, new Color(.246f, 0, 0), .2f));
            this.DelayCoroutine(Animations.FadeSprite(fe, new Color(0, 0, 0), .2f), .21f);
            this.DelayCoroutine(Animations.FadeSprite(fe, new Color(.246f, 0, 0), .2f), .42f);
            this.DelayCoroutine(Animations.FadeSprite(fe, new Color(0, 0, 0), .2f), .63f);
            yield return new WaitForSeconds(3.5f);
        }
    }
}
