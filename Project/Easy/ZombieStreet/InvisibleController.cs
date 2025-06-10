using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleController : MonoBehaviour
{
    private HealthControler hc;
    private SpriteFlash flash;

    private void Awake()
    {
        hc = GetComponent<HealthControler>();
        flash = GetComponent<SpriteFlash>();
    }
    public void StartInvisible(float InvisibleTime,Color FlashColor,int FlashCount)
    {
        StartCoroutine(InvisibleCoroutine(InvisibleTime, FlashColor, FlashCount));
    }

    private IEnumerator InvisibleCoroutine(float InvisibleTime,Color FlashColor,int FlashCount)
    {
        hc.Invisible = true;
        yield return flash.FlashCoroutine(InvisibleTime, FlashColor, FlashCount);
        hc.Invisible = false;
    }
}
