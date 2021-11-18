using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager context;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        context = this;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Scene1":
                Cutscene.Play(Cutscene.Scene.Scene1);
                break;
            case "Interview1":
                Cutscene.Play(Cutscene.Scene.Scene2);
                break;
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Scene1":
                Cutscene.Play(Cutscene.Scene.Scene1);
                break;
            case "Interview1":
                Cutscene.Play(Cutscene.Scene.Scene2);
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
            }    
        }

        private static IEnumerator Scene1()
        {
            context.GetComponent<AudioSource>().PlayOneShot(AssetBank.KaiTrack, .25f);

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
            context.StartCoroutine(Animations.FadeSprite(fadeSprite, new Color(0, 0, 0, 1), 3));

            yield return new WaitForSeconds(3f);

            var text = TextSystem.Create(new Vector2(400, 80), new Vector2(3.5f, .25f), fontData:new FontData { fontSize = 60, fontStyle = FontStyle.Bold }, color: new Color(1, 1, 1));//rawText.Access();
            yield return null;
            context.StartCoroutine(text.AnimateText("The interview", .05f));
            yield return new WaitForSeconds(3f);
            context.StartCoroutine(text.AnimateTextOut(.05f));
            yield return new WaitForSeconds(2f);
            context.StartCoroutine(Animations.FadeSprite(fadeSprite, new Color(0, 0, 0, 0), 3));

            Destroy(text);

            yield return new WaitForSeconds(3f);
            Destroy(fadeSprite.gameObject);

            GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
            GameObject.Find("Monitor").GetComponent<PC_Interactible>().enabled = true;
        }

        private static IEnumerator Scene2()
        {
            context.GetComponent<AudioSource>().Stop();
            var bubble = SpeechBubble.Create("Boy, is it nice out here. A warm, sunny day, and the best part?", 0, new Vector2(100, 40), new Vector2(360, 120), new Vector2(3, 1), GameObject.Find("Player"));
            yield return null;
            bubble.UpdateVisuals();
            context.GetComponent<AudioSource>().PlayOneShot(AssetBank.HeartBeat, .5f);

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
            context.GetComponent<AudioSource>().PlayOneShot(AssetBank.BossBattle, .25f);

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
            bossBubble.Delay = .005f;
            yield return null;

            bossBubble.TextBox.color = new Color(1, 0, 0);

            bossBubble.UpdateVisuals();

            yield return new WaitForSeconds(4f);

            bossBubble.Text = "Fine. prove yourself in a battle of code.";
            bossBubble.UpdateVisuals();

            yield return new WaitForSeconds(4f);
            Destroy(bossBubble.gameObject);
            GameObject.Find("Boss").GetComponent<BossBattle>().Trigger();
        }

        public enum Scene
        {
            Scene1,
            Scene2
        }
    }
}
