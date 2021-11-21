using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossBattleGame : MonoBehaviour
{
    private List<Phase> Phases;
    private Phase CurrentPhase;

    private int Health;
    private Text PlayerHealth;
    private SpriteRenderer FadeEffect;

    private int CurrentPhaseNumber = 0;
    private float Elapsed = 0;
    private float GameTime = 0;
    private bool Running = false;

    public class Phase
    {
        public float Time;
        public float SpawnInterval = 1;
        public float Prob2 = 1;
        public float Speed2 = 1.5f;
        public float Speed1 = 1.5f;
    }

    public void StartBattle(List<Phase> phases, Text playerHealth, int startHealth)
    {
        FadeEffect = Instantiate(AssetBank.FadeEffect).GetComponent<SpriteRenderer>();
        FadeEffect.color = new Color(1, 0, 0, 0);

        Phases = phases;
        CurrentPhase = Phases[0];
        PlayerHealth = playerHealth;
        playerHealth.color = new Color(0, 1, .066f);
        Health = startHealth;
        PlayerHealth.text = $"Health: {Health}";
        Running = true;
    }

    private void Update()
    {
        if (Running)
        {
            Elapsed += Time.deltaTime;
            GameTime += Time.deltaTime;
            if (GameTime >= CurrentPhase.Time)
            {
                CurrentPhaseNumber++;
                if (CurrentPhaseNumber == Phases.Count)
                {
                    Running = false;
                    PlayerHealth.enabled = false;
                    return;
                }
                CurrentPhase = Phases[CurrentPhaseNumber];
                GameTime = 0;
            }
            if (Elapsed >= CurrentPhase.SpawnInterval)
            {
                Elapsed = 0;

                if (Random.Range(0, 1000) <= CurrentPhase.Prob2 * 1000)
                    StartCoroutine(Float2(Instantiate(AssetBank.Two, new Vector3(Random.Range(-6f, 6f), 5, -2), Quaternion.identity), CurrentPhase.Speed2));
                else
                    StartCoroutine(Float2(Instantiate(AssetBank.One, new Vector3(Random.Range(-6f, 6f), 5, -2), Quaternion.identity), CurrentPhase.Speed1));
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
                Health--;
                if (Health <= 0) SceneManager.LoadScene("GameOver");
                if (FadeEffect.color.a == 0)
                {
                    StartCoroutine(Animations.FadeSprite(FadeEffect, new Color(.95f, 0, 0, 1), .125f));
                    DelayCoroutine(Animations.FadeSprite(FadeEffect, new Color(.95f, 0, 0, 0), .25f), .125f);
                }
            }
            else
                Health += 2;
            PlayerHealth.text = $"Health: {Health}";
        }
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
