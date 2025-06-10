using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyCollectable : MonoBehaviour
{
    [SerializeField]
    private float ChanceOfDrop;

    private CollectabelSpawner collectableSpawner;

    private void Awake()
    {
        collectableSpawner = FindObjectOfType<CollectabelSpawner>();
    }

    public void OnDrop()
    {
        float random = Random.Range(0f, 1f);
        if (random >= ChanceOfDrop)
        {
            collectableSpawner.SpawnCollectable(transform.position);
        }
    }
}
