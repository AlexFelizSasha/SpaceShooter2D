using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private int _poolSize = 10;

    private List<GameObject> _objectsPool;
    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        _objectsPool = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, Vector3.zero, Quaternion.identity);
            bullet.SetActive(false);
            _objectsPool.Add(bullet);
        }
    }
    public GameObject GetPooledObject()
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
}
