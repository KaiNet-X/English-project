using System.Collections;
using UnityEngine;

public static class Utils
{
    public static void DelayCoroutine(this MonoBehaviour ctx, IEnumerator cor, float seconds)
    {
        ctx.StartCoroutine(Delay(ctx, cor, seconds));
    }

    private static IEnumerator Delay(this MonoBehaviour ctx, IEnumerator cor, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ctx.StartCoroutine(cor);
    }
}
