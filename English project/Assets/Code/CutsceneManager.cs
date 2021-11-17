using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager context;

    public void Start()
    {
        context = this;

        Cutscene.Play(Cutscene.Scene.Scene1);
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
            }    
        }

        private static IEnumerator Scene1()
        {
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

            context.StartCoroutine(Animations.Interpolate(GameObject.Find("Player").transform, new Vector2(2.5f, -2.6f), 2));
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

        public enum Scene
        {
            Scene1
        }
    }
}
