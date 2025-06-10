using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamgeInvicity : MonoBehaviour
{
    private InvisibleController ic;
    [SerializeField]
    private float invisibleTime;
    [SerializeField]
    private Color FlashColor;
    [SerializeField]
    private int FlashCount;
    private void Awake()
    {
        ic = GetComponent<InvisibleController>();
    }
    public void StartInvisible()
    {
        ic.StartInvisible(invisibleTime, FlashColor, FlashCount);
    }

}
