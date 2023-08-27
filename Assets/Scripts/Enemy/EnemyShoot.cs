using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : ShipShoots
{
    private void Awake()
    {
        _bulletPool = GetComponent<BulletPool>();
    }
    private void Update()
    {
        if (gameObject.GetComponent<EnemyPlayerDistance>().IfPlayerClose)
        {
            GameObject _bullet = _bulletPool.GetPooledObject();
            FireAllBullets(_bullet);
        }
    }
}
