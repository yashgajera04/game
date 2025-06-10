using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollecterBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private int healthAmount;
    public void OnCollected(GameObject Player)
    {
        Player.GetComponent<HealthControler>().AddHealth(healthAmount);
    }
}
