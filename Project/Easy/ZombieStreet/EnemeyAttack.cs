using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyAttack : MonoBehaviour
{
    [SerializeField]
    private float DamageAmount;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            var healthController = other.gameObject.GetComponent<HealthControler>();
            healthController.TakeDameage(DamageAmount);
        }    
    }
}
