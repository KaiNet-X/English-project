using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LineStart;
    public GameObject G0;
    public GameObject G1;
    public GameObject G2;

    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        int lines = 7;
        int columns = 15;

        for (int y = 0; y < lines; y++)
        {
            Instantiate(LineStart).transform.position = new Vector2(-11, 4.1f) + (1.4f * new Vector2(0, -y));
            for (int x = 0; x < columns; x++)
            {
                RandNum().transform.position = new Vector2(-11, 4.1f) + (1.4f * new Vector2(x+1, -y));
            }
        }
    }

    private GameObject RandNum()
    {
        int ver = (int)Random.Range(0, 10);

        if (ver <= 4) return Instantiate(G0);
        else if (ver <= 8) return Instantiate(G1);
        else return Instantiate(G2);
    }
}
