using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static BossBattleGame;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager context;
    private static bool FirstReturn = true;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        context = this;
        SceneLoad();
    }
    private void OnLevelWasLoaded(int level)
    {
        SceneLoad();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
    }
    private void SceneLoad()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Scene1":
                Cutscene.Play(Cutscene.Scene.Scene1);
                break;
            case "Interview1":
                Cutscene.Play(Cutscene.Scene.Scene2);
                break;
            case "Interview2":
                Cutscene.Play(Cutscene.Scene.Scene3);
                break;
            case "Credits":
                Cutscene.Play(Cutscene.Scene.Scene4);
                break;
            case "Home":
                var fe = GameObject.Find("FadeEffect").GetComponent<SpriteRenderer>();

                if (FirstReturn) FirstReturn = false;
                else fe.sortingOrder = 5;

                StartCoroutine(Animations.FadeSprite(fe, new Color(0, 0, 0, 0), 2.5f));
                break;
            case "Desktop":
                if (!BinaryClicked.FirstTime)
                {
                    if (!DesktopManager.Interview1Load)
                        StartCoroutine(Animations.Interpolate(GameObject.Find("Notif1").transform, new Vector2(5.0733f, 4.08f), 2));
                    else
                        StartCoroutine(Animations.Interpolate(GameObject.Find("Notif2").transform, new Vector2(5.0733f, 4.08f), 2));
                }
                break;
        }
    }

    public static class Cutscene
    {        
        public static void Play(Scene scene)
        {
            switch (scene)
            {
                case Scene.Scene1:
                    context.StartCoroutine(Scene1());
                    break;
                case Scene.Scene2:
                    context.StartCoroutine(Scene2());
                    break;
                case Scene.Scene3:
                    context.StartCoroutine(Scene3());
                    break;
                case Scene.Scene4:
                    context.StartCoroutine(Scene4());
                    break;
            }    
        }

        private static IEnumerator Scene1()
        {
            context.GetComponent<AudioSource>().PlayOneShot(AssetBank.KaiTrack, 1f);

            var bubble = SpeechBubble.Create("Senior year, what a bust.", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(3, 1), GameObject.Find("Player"));
            yield return null;
            bubble.UpdateVisuals();
            yield return new WaitForSeconds(2f);

            bubble.Text = "Nothing but teams meetings, day in, day out.";
            bubble.UpdateVisuals();
            yield return new WaitForSeconds(2f);

            bubble.Text = "It's finally over.";
            bubble.UpdateVisuals();
            yield return new WaitForSeconds(2f);

            bubble.Text = "Now what do I do?";
            bubble.UpdateVisuals();
            yield return new WaitForSeconds(2f);

            bubble.Text = "Oh yeah! I need a job!";
            bubble.UpdateVisuals();
            yield return new WaitForSeconds(2f);

            Destroy(bubble.gameObject);

            context.StartCoroutine(Animations.Interpolate(GameObject.Find("Player").transform, new Vector2(2.5f, -1.6f), 2));
            yield return new WaitForSeconds(2f);

            var fadeSprite = Instantiate(AssetBank.FadeEffect).GetComponent<SpriteRenderer>();
            fadeSprite.color = new Color(0, 0, 0, 0);
            fadeSprite.sortingOrder = 3;
            context.StartCoroutine(Animations.FadeSprite(fadeSprite, new Color(0, 0, 0, 1), 3));

            yield return new WaitForSeconds(3f);

            var text = TextSystem.Create(new Vector2(400, 80), new Vector2(3.5f, .25f), fontData: new FontData { fontSize = 60, fontStyle = FontStyle.Bold }, color: new Color(1, 1, 1));//rawText.Access();
            yield return null;
            context.StartCoroutine(text.AnimateText("The interview", .05f));
            yield return new WaitForSeconds(3f);
            context.StartCoroutine(text.AnimateTextOut(.05f));
            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene("Home");
        }

        private static IEnumerator Scene2()
        {
            context.GetComponent<AudioSource>().Stop();
            var bubble = SpeechBubble.Create("Boy, is it nice out here. A warm, sunny day, and the best part?", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(3, 1), GameObject.Find("Player"));
            yield return null;
            bubble.UpdateVisuals();
            context.GetComponent<AudioSource>().PlayOneShot(AssetBank.HeartBeat, 2.5f);

            yield return new WaitForSeconds(2f);

            bubble.Size = new Vector2(50, 20);
            bubble.TextSize = new Vector2(150, 40);
            bubble.Offset = new Vector2(1.5f, 1);
            bubble.Text = "It's Quiet!";
            bubble.UpdateVisuals();

            yield return new WaitForSeconds(2f);

            bubble.Size = new Vector2(30, 20);
            bubble.TextSize = new Vector2(60, 40);
            bubble.Offset = new Vector2(1f, 1);
            bubble.Text = "";
            bubble.UpdateVisuals();

            yield return new WaitForSeconds(1.5f);

            bubble.Text = "........";
            bubble.Delay = .25f;
            bubble.UpdateVisuals();
            context.GetComponent<AudioSource>().Stop();
            context.GetComponent<AudioSource>().PlayOneShot(AssetBank.BossBattle, .75f);

            yield return new WaitForSeconds(4f);

            bubble.Size = new Vector2(100, 40);
            bubble.TextSize = new Vector2(360, 120);
            bubble.Offset = new Vector2(3, 1);
            bubble.Text = "This sure is taking a while. And where the heck is that music coming from!?";
            bubble.Delay = 0;
            bubble.UpdateVisuals();

            yield return new WaitForSeconds(3f);

            bubble.Size = new Vector2(30, 20);
            bubble.TextSize = new Vector2(60, 40);
            bubble.Offset = new Vector2(1f, 1);
            bubble.Text = "........";
            bubble.Delay = .25f;
            bubble.UpdateVisuals();

            yield return new WaitForSeconds(3f);

            bubble.Size = new Vector2(90, 20);
            bubble.TextSize = new Vector2(300, 40);
            bubble.Offset = new Vector2(3, 1);
            bubble.Text = "Was this a bad idea?";
            bubble.Delay = 0;
            bubble.UpdateVisuals();

            yield return new WaitForSeconds(3f);

            Destroy(bubble.gameObject);

            context.StartCoroutine(Animations.Interpolate(GameObject.Find("Boss").transform, new Vector2(-1.58f, -2.4f), 4));
            yield return new WaitForSeconds(7f);

            var bossBubble = SpeechBubble.Create("So... you want an interview do you?", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(0, 2.5f), GameObject.Find("Boss"));
            bossBubble.Delay = .05f;
            yield return null;

            bossBubble.TextBox.color = new Color(1, 0, 0);

            bossBubble.UpdateVisuals();

            yield return new WaitForSeconds(4f);

            bossBubble.Text = "Fine. prove yourself in a battle of code.";
            bossBubble.UpdateVisuals();

            yield return new WaitForSeconds(4f);
            Destroy(bossBubble.gameObject);
            GameObject.Find("Boss").GetComponent<BossBattle>().Trigger();

            yield return new WaitForSeconds(35f);
            bubble = SpeechBubble.Create("I can do this...", 0, new Vector2(75, 25), new Vector2(280, 120), new Vector2(0, 2), GameObject.Find("Player"));
            yield return null;
            bubble.UpdateVisuals();

            yield return new WaitForSeconds(3f);
            Destroy(bubble.gameObject);

            yield return new WaitForSeconds(2f);

            bossBubble = SpeechBubble.Create("We'll see about that.", 0, new Vector2(75, 25), new Vector2(280, 120), new Vector2(0, 2), GameObject.Find("Boss"));
            bossBubble.Delay = .05f;
            yield return null;
            bossBubble.TextBox.color = new Color(1, 0, 0);
            bossBubble.UpdateVisuals();
            yield return new WaitForSeconds(3f);
            Destroy(bossBubble.gameObject);
            yield return new WaitForSeconds(2f);
            bubble = SpeechBubble.Create(".....", 0, new Vector2(30, 20), new Vector2(60, 40), new Vector2(0, 2), GameObject.Find("Player"));
            yield return null;
            bubble.UpdateVisuals();
            yield return new WaitForSeconds(3f);
            Destroy(bubble.gameObject);
            yield return new WaitForSeconds(66f);
            bossBubble = SpeechBubble.Create("Very well. The interview is yours. You must prepare.", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(0, 2.5f), GameObject.Find("Boss"));
            bossBubble.Delay = .07f;
            GameObject.Find("PlayerHealth").SetActive(false);
            yield return null;
            bossBubble.TextBox.color = new Color(1, 0, 0);

            bossBubble.UpdateVisuals();
            yield return new WaitForSeconds(4.5f);

            Destroy(bossBubble.gameObject);
            context.StartCoroutine(Animations.Interpolate(GameObject.Find("Boss").transform, new Vector2(-1.58f, 11), 3));

            yield return new WaitForSeconds(6f);

            var fade = Instantiate(AssetBank.FadeEffect).GetComponent<SpriteRenderer>();
            fade.color = new Color(0, 0, 0, 0);
            context.StartCoroutine(Animations.FadeSprite(fade, new Color(0, 0, 0, 1), 2.5f));
            yield return new WaitForSeconds(3f);

            SceneManager.LoadScene("Home");
        }

        private static IEnumerator Scene3()
        {
            var boss = GameObject.Find("Boss");
            var player = GameObject.Find("Player");
            context.GetComponent<AudioSource>().Stop();
            context.GetComponent<AudioSource>().PlayOneShot(AssetBank.BossBattle2, .5f);

            var bossBubble = SpeechBubble.Create("Impressive. Few have made it even this far.", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(-3, 1), boss);

            yield return new WaitForSeconds(2);
            bossBubble.TextBox.color = new Color(1, 0, 0);
            bossBubble.UpdateVisuals();

            bossBubble.Text = "But this interview will be your true test of skill. I hope you have prepared well.";
            yield return new WaitForSeconds(2);
            bossBubble.UpdateVisuals();
            yield return new WaitForSeconds(2);

            Destroy(bossBubble.gameObject);

            List<Phase> phases = new List<Phase>()
            {
                new Phase
                {
                    Time = 9,
                    SpawnInterval = .8f,
                    Prob2 = 1,
                    Speed2 = 1f
                },
                new Phase
                {
                    Time = 8,
                    SpawnInterval = 30
                },
                new Phase
                {
                    Time = 17,
                    SpawnInterval = .5f,
                    Prob2 = .8f,
                    Speed1 = 1.5f,
                    Speed2 = 1.75f
                },
                new Phase
                {
                    Time = 15,
                    SpawnInterval = .3f,
                    Prob2 = .75f,
                    Speed1 = 1.5f,
                    Speed2 = 1.75f
                },
                new Phase
                {
                    Time = 7,
                    SpawnInterval = .1f,
                    Prob2 = .5f,
                    Speed1 = 1.5f,
                    Speed2 = 3
                },
                new Phase
                {
                    Time = 15,
                    SpawnInterval = .3f,
                    Prob2 = .8f,
                    Speed1 = 1.5f,
                    Speed2 = 1.75f
                },
                new Phase
                {
                    Time = 3,
                    SpawnInterval = .2f,
                    Prob2 = 1f,
                    Speed1 = 2f,
                    Speed2 = 2f
                },
                new Phase
                {
                    Time = 3,
                    SpawnInterval = .2f,
                    Prob2 = .8f,
                    Speed1 = 3f,
                    Speed2 = 2f
                },
                new Phase
                {
                    Time = 5,
                    SpawnInterval = .2f,
                    Prob2 = 1f,
                    Speed1 = 1.5f,
                    Speed2 = 1.75f
                },
                new Phase
                {
                    Time = 8,
                    SpawnInterval = .15f,
                    Prob2 = .7f,
                    Speed1 = 2f,
                    Speed2 = 3f
                },
                new Phase
                {
                    Time = 3,
                    SpawnInterval = .2f,
                    Prob2 = 1f,
                    Speed1 = 1.5f,
                    Speed2 = 2f
                },
                new Phase
                {
                    Time = 3,
                    SpawnInterval = 66,
                },
                new Phase
                {
                    Time = 3,
                    SpawnInterval = .2f,
                    Prob2 = 1f,
                    Speed1 = 1.5f,
                    Speed2 = 2f
                },
                new Phase
                {
                    Time = 5f,
                    SpawnInterval = 66,
                },
                new Phase
                {
                    Time = 12,
                    SpawnInterval = .1f,
                    Prob2 = .7f,
                    Speed1 = 1.5f,
                    Speed2 = 3
                },
                new Phase
                {
                    Time = 5f,
                    SpawnInterval = 9f,
                },
                new Phase
                {
                    Time = 2f,
                    SpawnInterval = .05f,
                    Prob2 = 0f,
                    Speed1 = 4.5f
                }
            };
            GameObject.Find("Boss").GetComponent<BossBattleGame>().StartBattle(phases, GameObject.Find("PlayerHealth").GetComponent<Text>(), 15);

            yield return new WaitForSeconds(126);
            
            bossBubble = SpeechBubble.Create("Only two others have made it as far as you have. ", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(-3, 1), boss);

            yield return null;
            bossBubble.TextBox.color = new Color(1, 0, 0);
            bossBubble.UpdateVisuals();

            yield return new WaitForSeconds(2.5f);

            bossBubble.Text = "Now the council will decide your fate.";
            bossBubble.UpdateVisuals();

            context.GetComponent<AudioSource>().PlayOneShot(AssetBank.HeartBeat, 2.5f);

            var c1 = SpeechBubble.Create(".....", .25f, new Vector2(50, 20), new Vector2(120, 60), new Vector2(0, 1), GameObject.Find("c1"));
            var c2 = SpeechBubble.Create(".....", .25f, new Vector2(50, 20), new Vector2(120, 60), new Vector2(0, 1), GameObject.Find("c2"));
            var c3 = SpeechBubble.Create(".....", .25f, new Vector2(50, 20), new Vector2(120, 60), new Vector2(0, 1), GameObject.Find("c3"));

            yield return new WaitForSeconds(2.5f);
            Destroy(bossBubble.gameObject);
            c1.UpdateVisuals();
            c2.UpdateVisuals();
            c3.UpdateVisuals();
            yield return new WaitForSeconds(2f);

            c1.UpdateVisuals();
            c2.UpdateVisuals();
            c3.UpdateVisuals();
            yield return new WaitForSeconds(2f);

            c1.UpdateVisuals();
            c2.UpdateVisuals();
            c3.UpdateVisuals();
            yield return new WaitForSeconds(3f);
            Destroy(c1.gameObject);
            Destroy(c2.gameObject);
            Destroy(c3.gameObject);

            context.StartCoroutine(Animations.Interpolate(boss.transform, new Vector2(boss.transform.position.x, -2.72f), .5f));

            yield return new WaitForSeconds(1.5f);
            context.StartCoroutine(Animations.Interpolate(boss.transform, new Vector2(1.51f, boss.transform.position.y), 1.5f));
            context.StartCoroutine(Animations.Interpolate(player.transform, new Vector2(player.transform.position.x, -2.72f), .5f));

            yield return new WaitForSeconds(1.5f);
            context.StartCoroutine(Animations.Interpolate(player.transform, new Vector2(-1.07f, player.transform.position.y), 1.5f));

            yield return new WaitForSeconds(3.5f);
            context.StartCoroutine(Animations.Interpolate(boss.transform.GetChild(0), new Vector2(0, boss.transform.GetChild(0).position.y), 2f));

            yield return new WaitForSeconds(2f);
            context.StartCoroutine(Animations.Interpolate(boss.transform.GetChild(0), new Vector2(-boss.transform.GetChild(0).position.x, 10), 2f));

            yield return new WaitForSeconds(2f);
            context.GetComponent<AudioSource>().Stop();
            bossBubble = SpeechBubble.Create("You're hired! welcome to the team! ", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(0, 3), boss);

            yield return null;
            bossBubble.UpdateVisuals();
            yield return new WaitForSeconds(2.5f);
            Destroy(bossBubble.gameObject);
            var fe = Instantiate(AssetBank.FadeEffect).GetComponent<SpriteRenderer>();
            fe.sortingOrder = 3;
            fe.color = new Color(0, 0, 0, 0);
            context.StartCoroutine(Animations.FadeSprite(fe, new Color(0, 0, 0), 3f));
            context.GetComponent<AudioSource>().PlayOneShot(AssetBank.Credits);

            yield return new WaitForSeconds(2.5f);
            SceneManager.LoadScene("Credits");
        }

        private static IEnumerator Scene4()
        {
            context.StartCoroutine(CreditItem(Head(), "Music: "));

            yield return new WaitForSeconds(.5f);
            context.StartCoroutine(CreditItem(Sub(), "\"Boss\" by Kai Schellin"));

            yield return new WaitForSeconds(.5f);
            context.StartCoroutine(CreditItem(Sub(), "\"The Epic Boss Fight\" by David Fesliyan"));

            yield return new WaitForSeconds(.5f);
            context.StartCoroutine(CreditItem(Sub(), "\"Boss Battle Rock\" by David Fesliyan"));

            yield return new WaitForSeconds(.5f);
            context.StartCoroutine(CreditItem(Sub(), "\"Melodic Techno #03 Extended Version - Moogify\" by Zen Man"));

            yield return new WaitForSeconds(1.5f);
            context.StartCoroutine(CreditItem(Head(), "Sprites:"));

            yield return new WaitForSeconds(.5f);
            context.StartCoroutine(CreditItem(Sub(), "Hacker (stock image)"));

            yield return new WaitForSeconds(.5f);
            context.StartCoroutine(CreditItem(Sub(), "Hacker mask (stock image)"));

            yield return new WaitForSeconds(.5f);
            context.StartCoroutine(CreditItem(Sub(), "All else (Kai Schellin)"));

            yield return new WaitForSeconds(1.5f);
            context.StartCoroutine(CreditItem(Head(), "Thats about it for the credits"));

            yield return new WaitForSeconds(3.5f);

            var player = GameObject.Find("Player");
            var boss = GameObject.Find("Boss");

            Vector3 pScale = player.transform.localScale;
            Vector3 bScale = boss.transform.localScale;

            player.transform.localScale = new Vector3(pScale.x * -1, pScale.y, pScale.z);
            boss.transform.localScale = new Vector3(bScale.x * -1, bScale.y, bScale.z);

            context.StartCoroutine(Animations.InterpolateRelative(player.transform, new Vector2(-11, 0), 5));
            context.StartCoroutine(Animations.InterpolateRelative(boss.transform, new Vector2(11, 0), 5));
            yield return new WaitForSeconds(6.5f);

            boss.transform.position = new Vector3(2.62f, -2.13f);
            player.transform.position = new Vector3(-3.09f, -2.17f);
            player.transform.localScale = new Vector3(1.833005f, player.transform.localScale.y, player.transform.localScale.z);
            boss.transform.localScale = new Vector3(1.450662f, boss.transform.localScale.y, boss.transform.localScale.z);
            var fe = GameObject.Find("FadeEffect").GetComponent<SpriteRenderer>();
            fe.sortingOrder = 5;
            context.StartCoroutine(Animations.FadeSprite(fe, new Color(0, 0, 0, 0), 3));
            yield return new WaitForSeconds(3.5f);

            var bossBubble = SpeechBubble.Create("How are you liking it here so far?", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(0, 2.5f), GameObject.Find("Boss"));
            yield return null;
            bossBubble.UpdateVisuals();
            yield return new WaitForSeconds(3);

            Destroy(bossBubble.gameObject);
            var bubble = SpeechBubble.Create("It's great here! Not a hacker mask in sight!", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(0, 2), GameObject.Find("Player"));
            yield return null;
            bubble.UpdateVisuals();

            yield return new WaitForSeconds(3);
            Destroy(bubble.gameObject);
            bossBubble = SpeechBubble.Create("Amazing! Now we must create the new google", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(0, 2.5f), GameObject.Find("Boss"));
            yield return null;
            bossBubble.UpdateVisuals();

            yield return new WaitForSeconds(3);
            Destroy(bossBubble.gameObject);
            context.StartCoroutine(Animations.FadeSprite(fe, new Color(0, 0, 0, 1), 3));
        }

        private static IEnumerator CreditItem(TextSystem tx, string text)
        {
            yield return null;
            context.StartCoroutine(tx.AnimateText(text, 0));
            context.StartCoroutine(Animations.InterpolateRelative(tx.transform, new Vector2(0, 12), 8));
        }
        private static TextSystem Head()
        {
            return TextSystem.Create(
                new Vector2(1000, 125),
                new Vector2(-3, -6),
                fontData: new FontData
                {
                    fontSize = 60,
                    fontStyle = FontStyle.Bold
                },
                color: new Color(1, 1, 1));
        }

        private static TextSystem Sub()
        {
            return TextSystem.Create(
                new Vector2(1000, 125),
                new Vector2(-3, -6),
                fontData: new FontData
                {
                    fontSize = 48,
                    fontStyle = FontStyle.Bold
                },
                color: new Color(1, 1, 1));
        }
        public enum Scene
        {
            Scene1,
            Scene2,
            Scene3,
            Scene4
        }
    }
}
