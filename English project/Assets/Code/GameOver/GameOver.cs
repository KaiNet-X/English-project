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
        var txt = TextSystem.Create(
        new Vector2(600, 100),
        new Vector2(0, 150),
        new Vector2(.5f, .5f),
        new FontData
        {
            fontStyle = FontStyle.Bold,
            fontSize = 55
        },
        new Color(1f, 1f, 0));

        yield return null;

        for (int i = 0; i < 10; i++)
        {
            StartCoroutine(txt.AnimateText("ERROR: Game over", .1f));
            yield return new WaitForSeconds(3.5f);
        }
    }
}
