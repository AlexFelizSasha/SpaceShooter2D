using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawning : MonoBehaviour
{
    [SerializeField]
    public GameObject[] _enemyShip = new GameObject[3];
    [SerializeField]
    public Transform[] EnemySpawnPoints = new Transform[5];
    float _currentHealth;
    float _timeToCreate;
    private void Awake()
    {
        _currentHealth = gameObject.GetComponent<Statistics>().CurrentHealth;
        _timeToCreate = 0; 
    }
    private void Update()
    {
        if (Time.time - _timeToCreate >= 3f)
            SpawnEnemies();
    }
    protected void CreateEnemy()
    {
        Transform _spawnPoint = EnemySpawnPoints[Random.Range(0, 4)];
        Vector3 _spawnPointPosition = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, 0);
        Instantiate(_enemyShip[ChooseEnemyShip()], _spawnPointPosition, Quaternion.identity);
        Debug.Log($"Enemy Created here: {_spawnPoint.position.x}, {_spawnPoint.position.y}");
    }
    protected int ChooseEnemyShip()
    {
        return Random.Range(0, _enemyShip.Length);
    }
    private void SpawnEnemies()
    {
        if (_currentHealth != gameObject.GetComponent<Statistics>().CurrentHealth)
        {            
            CreateEnemy();
            _currentHealth = gameObject.GetComponent<Statistics>().CurrentHealth;
            _timeToCreate = Time.time;
        }
    }
}
