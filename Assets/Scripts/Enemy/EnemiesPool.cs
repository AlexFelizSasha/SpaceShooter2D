using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPool : AsteroidsPool
{
    private void Awake()
    {
        _spawnTime = 5f;
       _poolSize = DifficultyValues.EnemiesAmount();
    }
    private void Start()
    {
        InitializePool();
        StartCoroutine(KeepSpawningObjects());
    }
}
