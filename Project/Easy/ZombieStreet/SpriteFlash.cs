using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void StartFlsh(float duration, Color flashcolor, int FlashCount)
    {
       StartCoroutine(FlashCoroutine(duration, flashcolor, FlashCount));
    }
    public IEnumerator FlashCoroutine(float duration, Color flashcolor, int FlashCount)
    {
        Color StartColor = spriteRenderer.color;
        float eplasrdFlashTime = 0;
        float eplasrdFlashPerctage = 0;

        while (eplasrdFlashTime < duration)
        {
            eplasrdFlashTime += Time.deltaTime;
            eplasrdFlashPerctage = eplasrdFlashTime / duration;

            if (eplasrdFlashPerctage > 1f)
            {
                eplasrdFlashPerctage = 1f;
            }
            float pingpongpercentage = Mathf.PingPong(eplasrdFlashPerctage * 2 * FlashCount, 1);
            spriteRenderer.color = Color.Lerp(StartColor, flashcolor, pingpongpercentage);
            yield return null;
        }
    }
}
