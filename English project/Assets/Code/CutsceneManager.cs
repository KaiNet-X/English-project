using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public GameObject SpeechBubble;
    public GameObject Text;
    public GameObject FadeEffect;
    public Sprite PcOn;
    public static CutsceneManager context;

    public void Start()
    {
        context = this;

        Cutscene.Action.CreateBubble.SpeechBubble = SpeechBubble;
        Cutscene.Action.ScreenFade.FadeObject = FadeEffect;
        Cutscene.Action.CreateRawText.RawText = Text;

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
            var a = new Action.CreateBubble
            {
                OwnerName = "Player",
                ParentName = "Canvas",
                Text = "Senior year, what a bust.",
                Size = new Vector2(100, 40),
                TextSize = new Vector2(360, 120),
                Offset = new Vector2(3, 1),
            };
            var go = a.Access();

            yield return new WaitForSeconds(1.6f);

            var Mod = new Action.ModifyBubble
            {
                Text = "Nothing but teams meetings, day in, day out.",
                Bubble = go
            };
            Mod.Start();

            yield return new WaitForSeconds(1.8f);

            Mod = new Action.ModifyBubble
            {
                Text = "It's finally over.",
                Bubble = go
            };

            Mod.Start();

            yield return new WaitForSeconds(1.8f);

            Mod = new Action.ModifyBubble
            {
                Text = "Now what do I do?",
                Bubble = go
            };

            Mod.Start();

            yield return new WaitForSeconds(1.8f);

            Mod = new Action.ModifyBubble
            {
                Text = "Oh yeah! I need a job!",
                Bubble = go
            };

            Mod.Start();

            yield return new WaitForSeconds(1.8f);

            Destroy(go.gameObject);

            var move = new Action.MoveObject
            {
                ObjectName = "Player",
                Time = 2f,
                ToPosition = new Vector2(2.5f, -2.6f)
            };

            move.Start();

            yield return new WaitForSeconds(2f);

            var fade = new Action.ScreenFade
            {
                Time = 3,
                Color = new Color(0, 0, 0),
                In = true
            };

            var obj = fade.Access();

            yield return new WaitForSeconds(3f);

            var rawText = new Action.CreateRawText
            {
                Text = "The interview",
                ParentName = "Canvas",
                Color = new Color(1, 1, 1),
                Delay = .05f,
                Size = new Vector2(400, 80),
                Position = new Vector2(0, 0)
            };

            var text = rawText.Access();

            yield return new WaitForSeconds(3f);

            fade = new Action.ScreenFade
            {
                Time = 3,
                Color = new Color(0, 0, 0),
                In = false
            };
            Destroy(text);
            var obj2 = fade.Access();

            Destroy(obj);

            yield return new WaitForSeconds(3f);
            Destroy(obj2);

        }

        public enum Scene
        {
            Scene1
        }

        public abstract class Action
        {
            protected abstract IEnumerator Run();
            public void Start() => context.StartCoroutine(Run());

            public abstract class ReturningAction<T> : Action
            {
                protected T accessor;

                public T Access()
                {
                    Start();
                    while (accessor == null) continue;
                    return accessor;
                }
            }

            public class CreateBubble : ReturningAction<SpeechBubble>
            {
                public static GameObject SpeechBubble;

                public Vector2 Size;
                public Vector2 TextSize;
                public Vector2 Offset;

                public int FontSize = 28;
                public FontStyle FontStyle = FontStyle.Bold;
                public Font Font;

                public string Text;
                public string OwnerName;
                public string ParentName;

                public float Delay;

                protected override IEnumerator Run()
                {
                    var obj = Instantiate(SpeechBubble, GameObject.Find(ParentName).transform);
                    var bubble = obj.GetComponent<SpeechBubble>();
                    var text = obj.transform.GetChild(0).GetComponent<Text>();

                    text.fontSize = FontSize;
                    text.fontStyle = FontStyle;
                    if (Font != null) text.font = Font;

                    bubble.Owner = GameObject.Find(OwnerName);
                    bubble.TextSize = TextSize;
                    bubble.Size = Size;
                    bubble.Offset = Offset;
                    bubble.Text = Text;
                    bubble.Delay = Delay;

                    accessor = bubble;

                    yield return null;

                    bubble.Init();
                }
            }

            public class ModifyBubble : Action
            {
                public string Text;
                public float Delay;
                public SpeechBubble Bubble;

                protected override IEnumerator Run()
                {
                    Bubble.Delay = Delay;
                    Bubble.Text = Text;
                    Bubble.Init();

                    yield return null; 
                }
            }

            public class CreateRawText : ReturningAction<GameObject>
            {
                public static GameObject RawText;

                public string ParentName;
                public string Text;

                public float Delay;

                public Vector2 Position;
                public Vector2 Size;

                public int FontSize = 60;
                public FontStyle FontStyle = FontStyle.Bold;
                public Font Font;
                public Color Color;

                protected override IEnumerator Run()
                {
                    var textField = accessor = Instantiate(RawText, GameObject.Find(ParentName).transform);
                    var text = textField.GetComponent<Text>();
                    var textSystem = textField.GetComponent<TextSystem>();

                    textField.transform.position = Position;
                    textField.GetComponent<RectTransform>().sizeDelta = Size;

                    if (Color != null) text.color = Color;
                    text.fontSize = FontSize;
                    text.fontStyle = FontStyle;
                    if (Font != null) text.font = Font;

                    yield return null;

                    context.StartCoroutine(textSystem.AnimateText(Text, Delay));
                }
            }

            public class MoveObject : Action
            {
                public Vector2 ToPosition;
                public string ObjectName;
                public float Time;

                protected override IEnumerator Run()
                {
                    float iterate = 0;

                    var obj = GameObject.Find(ObjectName);
                    Vector3 position = obj.transform.position;
                    
                    while (iterate < Time)
                    {
                        obj.transform.position = Vector3.Lerp(position, ToPosition, 1 / Time * iterate);
                        yield return null;
                        iterate += UnityEngine.Time.deltaTime;
                    }
                }
            }

            public class ScreenFade : ReturningAction<GameObject>
            {
                public static GameObject FadeObject;

                public int Time;
                public bool In;
                public Color Color;

                protected override IEnumerator Run()
                {
                    var obj = accessor = Instantiate(FadeObject);
                    var sprite = obj.GetComponent<SpriteRenderer>();

                    float timer = 0;
                    float iterate = In ? 0 : 1;

                    while (timer < Time)
                    {
                        sprite.color = new Color(Color.r, Color.g, Color.b, iterate / Time);
                        yield return null;
                        timer += UnityEngine.Time.deltaTime;
                        iterate = In ? timer : iterate - UnityEngine.Time.deltaTime;
                    }
                    sprite.color = new Color(Color.r, Color.g, Color.b, In ? 255 : 0);
                }
            }
        }
    }
}
