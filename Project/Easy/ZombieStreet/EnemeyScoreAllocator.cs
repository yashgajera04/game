using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyScoreAllocator : MonoBehaviour
{
    [SerializeField]
    private int killScore;

    private ScoreController scoreController;

    private void Awake()
    {
        scoreController = FindObjectOfType<ScoreController>();

    }
    public void Allocatescore()
    {
        scoreController.AddScore(killScore);
    }
}
