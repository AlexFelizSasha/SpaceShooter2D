using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveSpawning : EnemiesSpawning
{
    private float _agressiveSpawnTime;
    private int _spawnAmount;
    public int _spawnLevel { get; private set; }
    private void Awake()
    {
        _agressiveSpawnTime = 2f;
        _spawnAmount = 5;
        _spawnLevel = 0;
    }
    private void Update()
    {
        
    }
    private void Start()
    {
        StartCoroutine(SpawnAgressive());
    }
    private IEnumerator SpawnAgressive()
    {
        for (int i = 1; i <= _spawnAmount; i++)
            CreateEnemy();
        _spawnLevel++;
        _spawnAmount++;
        yield return new WaitForSeconds(_agressiveSpawnTime);
    }
}
