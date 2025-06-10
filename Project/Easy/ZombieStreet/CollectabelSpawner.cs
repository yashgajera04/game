using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectabelSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> collectables;

    public void SpawnCollectable(Vector2 postion)
    {
        int index = Random.Range(0, collectables.Count);
        var collectable = collectables[index];
        Instantiate(collectable, postion, Quaternion.identity);
    }
}
