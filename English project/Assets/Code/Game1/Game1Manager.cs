using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game1Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public static int Errors = 0;
    public static int Score = 0;

    public static bool Running = false;

    void Start()
    {
        Score = 0;
        StartGame();
    }

    void StartGame()
    {
        int lines = 6;
        int columns = 8;
        for (int y = 0; y < lines; y++)
        {
            Instantiate(AssetBank.LineStart).transform.position = new Vector2(-6, 3.1f) + (1.4f * new Vector2(0, -y));
            for (int x = 0; x < columns; x++)
            {
                RandNum().transform.position = new Vector2(-6, 3.1f) + (1.4f * new Vector2(x+1, -y));
            }
        }
        Running = true;
        StartCoroutine(Run());
    }

    private GameObject RandNum()
    {
        int ver = (int)UnityEngine.Random.Range(0, 10);

        if (ver <= 4) return Instantiate(AssetBank.Zero);
        else if (ver <= 8) return Instantiate(AssetBank.One);
        else
        {
            Errors++;
            return Instantiate(AssetBank.Two);
        }
    }

    private IEnumerator Run()
    {
        float time = 20;
        var scoreText = GameObject.Find("Score").GetComponent<Text>();
        var timeText = GameObject.Find("Time").GetComponent<Text>();
        while (Running)
        {
            if (Errors == 0 || 0 >= time)
            {
                Running = false;
            }
            time -= Time.deltaTime;
            timeText.text = $"Time: {(int)time}";
            scoreText.text = $"Score: {Score}";
            yield return null;
        }
        if (Score > 0) AssetBank.HackerPoints += Score;
        SceneManager.LoadScene("Desktop");
    }
}
