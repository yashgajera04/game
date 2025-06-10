using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwaernes : MonoBehaviour
{
    public bool AwareOfPlayer{ get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }
    [SerializeField]
    private float PlayerAwarenessDistance;

    private Transform playerTransform;
  
    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 EnemeyToPlayer = playerTransform.position - transform.position;
        DirectionToPlayer = EnemeyToPlayer.normalized;
        if(EnemeyToPlayer.magnitude <= PlayerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
