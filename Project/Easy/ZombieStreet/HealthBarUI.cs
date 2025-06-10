using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image HealthFG;
    public void UpdateHealthBar(HealthControler hc)
    {
        HealthFG.fillAmount = hc.RemainingHealth;
    }
}
