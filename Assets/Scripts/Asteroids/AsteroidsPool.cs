using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsPool : MonoBehaviour
{
    public List<GameObject> SpawningObject = new List<GameObject>(6);
    public List<Transform> ObjectsSpawnPoints = new List<Transform>(10);
    

    protected int _poolSize;
    protected float _spawnTime;
    protected List<GameObject> _objectsPool;
    private void Awake()
    {
        _poolSize = 100;
        _spawnTime = 0.5f;
    }
    private void Start()
    {
        InitializePool();
        StartCoroutine(KeepSpawningObjects());
    }
    protected void InitializePool()
    {
        _objectsPool = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject asteroid = Instantiate(ChooseObject(SpawningObject), Vector3.zero, Quaternion.identity);
            asteroid.SetActive(false);
            _objectsPool.Add(asteroid);
        }
    }
    protected GameObject ChooseObject(List<GameObject> objectsList)
    {
        return objectsList[Random.Range(0, objectsList.Count)];
    }

    protected GameObject GetPooledObject()
    {
        foreach (GameObject spawnedObject in _objectsPool)
        {
            if (!spawnedObject.activeInHierarchy)
            {
                return spawnedObject;
            }
        }

        return null;
    }
    protected void SpawnObject()
    {
        GameObject spawnedObject = GetPooledObject();

        if (spawnedObject != null)
        {
            spawnedObject.transform.position = GetSpawnPoint(ObjectsSpawnPoints);
            spawnedObject.SetActive(true);
        }
    }
    protected Vector3 GetSpawnPoint(List<Transform> spawnPointsList)
    {
        return spawnPointsList[Random.Range(0, spawnPointsList.Count - 1)].position;
    }
    protected IEnumerator KeepSpawningObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            SpawnObject();
        }
    }
}

