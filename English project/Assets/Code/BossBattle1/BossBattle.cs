using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattle : MonoBehaviour
{
    private bool running = false;
    public int health = 15;
    private float time = 0;

    private SpriteRenderer fadeEffect;
    private Color baseColor = new Color(1, 0, 0, 0);
    private Text playerHealth;

    public void Trigger()
    {
        running = true;
        GameObject.Find("Player").GetComponent<BoxCollider2D>().enabled = false;
        playerHealth = GameObject.Find("PlayerHealth").GetComponent<Text>();
        playerHealth.color = new Color(0, 1, .066f);
        playerHealth.text = $"Health: {health}";
        fadeEffect = Instantiate(AssetBank.FadeEffect).GetComponent<SpriteRenderer>();
        fadeEffect.color = baseColor;
    }

    private void Update()
    {
        if (running)
        {
            time += Time.deltaTime;
            if (Random.Range(0, 1000) >= 996)
            {
                if ( time < 10)
                    StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity)));
                else if (time < 20)
                {
                    if (Random.Range(0, 5) >= 4)
                    {
                        StartCoroutine(Float2(Instantiate(AssetBank.One, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity)));
                    }
                    else
                    {
                        StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity)));
                    }
                }
                else if (time < 25)
                {

                }
                else if (time < 40)
                {
                    if (Random.Range(0, 6) >= 5)
                    {
                        StartCoroutine(Float2(Instantiate(AssetBank.One, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity)));
                    }
                    else
                    {
                        StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 2));
                    }
                }
            }
        }
    }

    private IEnumerator Float2(GameObject obj, float speed = 1.5f)
    {
        var bin = obj.GetComponent<BinaryValue>().Value;
        while (obj != null && obj.transform.position.y > -5)
        {
            obj.transform.Translate(new Vector3(0, -Time.deltaTime * speed));
            yield return null;
        }
        if (obj != null)
        {
            Destroy(obj);
            if (bin == 2)
            {
                health--;
                if (fadeEffect.color.a == 0)
                {
                    StartCoroutine(Animations.FadeSprite(fadeEffect, new Color(.95f, 0, 0, 1), .125f));
                    DelayCoroutine(Animations.FadeSprite(fadeEffect, new Color(.95f, 0, 0, 0), .25f), .125f);
                }
            }
            else
                health += 2;
        }
        playerHealth.text = $"Health: {health}";
    }

    private void DelayCoroutine(IEnumerator cor, float seconds)
    {
        StartCoroutine(Delay(cor, seconds));
    }

    private IEnumerator Delay(IEnumerator cor, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(cor);
    }
}
