using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{

    private Image fadeImage;
    private void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    public IEnumerator FadInCoroutine(float duration)
    {
        Color startcolor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);
        Color targetColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);

        yield return StartCoroutine(Fadecoroutine(startcolor, targetColor, duration));
        gameObject.SetActive(false);
    }
     public IEnumerator FadOutCoroutine(float duration)
    {
        Color startcolor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
        Color targetColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);
        gameObject.SetActive(true);
        yield return StartCoroutine(Fadecoroutine(startcolor, targetColor, duration));
       
    }
    private IEnumerator Fadecoroutine(Color StartColor, Color TargetColor, float duration)
    {
        float elpasedTime = 0f;
        float elpasedPercent = 0f;
        while (elpasedPercent < 1f)
        {
            elpasedPercent = elpasedTime / duration;
            fadeImage.color = Color.Lerp(StartColor, TargetColor, elpasedPercent);

            yield return null;
            elpasedTime += Time.deltaTime;
        }
    }
}
