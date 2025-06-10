using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float minSpawnTime;
    [SerializeField]
    private float maxSpawnTime;

    private float spawnTime;

    private void Awake()
    {
        SetTimeUntill();
    }
    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
           Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntill();
        }
    }
    private void SetTimeUntill()
    {
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
