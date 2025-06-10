using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyDamegS : MonoBehaviour
{
    [SerializeField]
    private float FlashDuration;
    [SerializeField]
    private Color SplashColor;

    [SerializeField]
    private int NumberOfSplash;

    private SpriteFlash sp;

    private void Awake()
    {
        sp = GetComponent<SpriteFlash>();
    }
    public void StartFlash()
    {
        sp.StartFlsh(FlashDuration, SplashColor, NumberOfSplash);
    }
}
