using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static BossBattleGame;

public class BossBattle : MonoBehaviour
{
    private bool Running = false;
    public int Health = 15;
    private float time = 0;
    private int Threshold = 950;
    private float Interval = .05f;
    private float Elapsed = 0;
    public Color SpriteColor;

    private SpriteRenderer fadeEffect;
    private Color baseColor = new Color(1, 0, 0, 0);
    private Text playerHealth;

    public void Trigger()
    {
        var bbg = GameObject.Find("Boss").GetComponent<BossBattleGame>();
        List<Phase> phases = new List<Phase>()
        {
            new Phase
            {
                Time = 20,
                Prob2 = 1
            },
            new Phase
            {
                Time = 10,
                Prob2 = .8f,
                SpawnInterval = .5f
            },
            new Phase
            {
                Time = 10,
                SpawnInterval = 11
            },
            new Phase
            {
                Time = 15,
                Speed2 = 2,
                SpawnInterval = .5f
            },
            new Phase
            {
                Time = 25,
                Prob2 = .6f,
                Speed1 = 1.15f,
                Speed2 = 2.25f,
                SpawnInterval = .5f
            },
            new Phase
            {
                Time = 10,
                SpawnInterval = 11
            },
            new Phase
            {
                Time = 10,
                Prob2 = 1,
                Speed2 = 3
            },
            new Phase
            {
                Time = 10,
                Prob2 = 1,
                Speed2 = 3,
                SpawnInterval = .25f
            }
        };
        bbg.StartBattle(phases, GameObject.Find("PlayerHealth").GetComponent<Text>(), 15);
        //Running = true;
        //GameObject.Find("Player").GetComponent<BoxCollider2D>().enabled = false;
        //playerHealth = GameObject.Find("PlayerHealth").GetComponent<Text>();
        //playerHealth.color = new Color(0, 1, .066f);
        //playerHealth.text = $"Health: {Health}";
        //fadeEffect = Instantiate(AssetBank.FadeEffect).GetComponent<SpriteRenderer>();
        //fadeEffect.color = baseColor;

        //StartCoroutine(GamePlay());
    }

    //private IEnumerator GamePlay()
    //{
    //    while (Running)
    //    {
    //        if (Random.Range(0, 1000) >= Threshold)
    //        {
    //            if (time < 10)
    //                StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity)));
    //            else if (time < 20)
    //            {
    //                if (Random.Range(0, 5) >= 4)
    //                {
    //                    StartCoroutine(Float2(Instantiate(AssetBank.One, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity)));
    //                }
    //                else
    //                {
    //                    StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity)));
    //                }
    //            }
    //            else if (time < 25)
    //            {

    //            }
    //            else if (time < 40)
    //            {
    //                if (Random.Range(0, 6) >= 5)
    //                {
    //                    StartCoroutine(Float2(Instantiate(AssetBank.One, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity)));
    //                }
    //                else
    //                {
    //                    StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 2));
    //                }
    //            }
    //            else if (time < 80)
    //            {
    //                if (Random.Range(0, 6) >= 4)
    //                {
    //                    StartCoroutine(Float2(Instantiate(AssetBank.One, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 1.15f));
    //                }
    //                else
    //                {
    //                    StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 2.25f));
    //                }
    //            }
    //            else if (time < 90)
    //            {
    //            }
    //            else if (time < 105)
    //            {
    //                Threshold = 850;
    //                if (Random.Range(0, 6) >= 4)
    //                {
    //                    StartCoroutine(Float2(Instantiate(AssetBank.One, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 1.5f));
    //                }
    //                else
    //                {
    //                    StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 2.5f));
    //                }
    //            }
    //        }
    //    }
    //}
    private void Update()
    {
        return;
        Elapsed += Time.deltaTime;
        if (Health <= 0)
        {
            Running = false;
            SceneManager.LoadScene("GameOver");
        }
        if (Running) time += Time.deltaTime;

        if (Running && Elapsed > Interval)
        {
            if (Random.Range(0, 1000) >= Threshold)
            {
                if (time < 20)
                    StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity)));
                else if (time < 35)
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
                else if (time < 45)
                {

                }
                else if (time < 60)
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
                else if (time < 85)
                {
                    if (Random.Range(0, 6) >= 4)
                    {
                        StartCoroutine(Float2(Instantiate(AssetBank.One, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 1.15f));
                    }
                    else
                    {
                        StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 2.25f));
                    }
                }
                else if (time < 95)
                {
                    Threshold = 725;
                }
                else if (time < 105)
                {
                    StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 3f));
                }
                //else if (time < 135)
                //{
                //    Threshold = 850;
                //    if (Random.Range(0, 6) >= 4)
                //    {
                //        StartCoroutine(Float2(Instantiate(AssetBank.One, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 1.5f));
                //    }
                //    else
                //    {
                //        StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 2.5f));
                //    }
                //}
                //else if (time < 150)
                //{
                //    StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6.5f, 6.5f), 5, -2), Quaternion.identity), 3f));
                //}
            }
        }
        if (Elapsed >= Interval) Elapsed = 0;
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
                Health--;
                if (fadeEffect.color.a == 0)
                {
                    StartCoroutine(Animations.FadeSprite(fadeEffect, new Color(.95f, 0, 0, 1), .125f));
                    DelayCoroutine(Animations.FadeSprite(fadeEffect, new Color(.95f, 0, 0, 0), .25f), .125f);
                }
            }
            else
                Health += 2;
        }
        playerHealth.text = $"Health: {Health}";
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
