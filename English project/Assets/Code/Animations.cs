using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Animations
{
    public static IEnumerator FadeSprite(SpriteRenderer sprite, Color newColor, float time)
    {
        static float Inter(float v1, float v2, float per)
        {
            return v1 + per * (v2 - v1);
        }

        float iteration = 0;
        float ratio = 0;
        Color c1 = sprite.color;

        while (iteration < time)
        {
            ratio = iteration / time;
            sprite.color = new Color(Inter(c1.r, newColor.r, ratio), Inter(c1.g, newColor.g, ratio), Inter(c1.b, newColor.g, ratio), Inter(c1.a, newColor.a, ratio));
            yield return null;
            iteration += Time.deltaTime;
        }
        sprite.color = newColor;
    }

    public static IEnumerator Interpolate(Transform transform, Vector2 toPosition, float time)
    {
        Vector2 pos = transform.position;
        float iteration = 0;

        while (iteration < time)
        {
            transform.position = Vector2.Lerp(pos, toPosition, iteration / time);
            yield return null;
            iteration += Time.deltaTime;
        }
        transform.position = toPosition;
    }
}
