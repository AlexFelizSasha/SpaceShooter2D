using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoots : PlayerShoots
{
    [SerializeField]
    private bool _enemyClose = false;
    [SerializeField]
    private List<GameObject> _bulletPrefabsList;

    public GameObject Builder;

    private void Awake()
    {
        _timeBetweenShots = 1f;
        _bulletSpeed = 4f;
    }

    private void Update()
    {
        if (_enemyClose)
            FireAllBullets(Missle());
    }
    private GameObject Missle()
    {
        StationBuilder _stationBuilder = Builder.GetComponent<StationBuilder>();
        int _stationLevel = _stationBuilder.StationLevel;
        if (_stationLevel <= 5)
            return _bulletPrefabsList[0];
        else return _bulletPrefabsList[1];
    }
}
