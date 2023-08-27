using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipShoots : MonoBehaviour
{
    public static event EventHandler<OnShipShootsEventArgs> OnShipShoots;
    public class OnShipShootsEventArgs : EventArgs
    {
        public Transform ShipTransform;
    }
    public List<Transform> FirePoints;  

    protected float _timeBetweenShots = 0.25f;
    protected float _bulletSpeed = 5f;
    protected float _lastTimeFire = 0;
    protected BulletPool _bulletPool;
    protected GameObject _bulletPrefab;
    
    protected void FireBullet(GameObject bulletPrefab, Transform firePoint, float bulletSpeed)
    {
        GameObject _bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        _bullet.gameObject.SetActive(true);
        Rigidbody2D _rigidbodyBullet = _bullet.GetComponent<Rigidbody2D>();
        Bullet _bulletComponent = _bullet.GetComponent<Bullet>();

        float _playerDamage = gameObject.GetComponent<Statistics>().Damage;
        _bulletComponent.SetDamage(_playerDamage);
        _rigidbodyBullet.velocity = transform.up * bulletSpeed;
    }
    protected void FireAllBullets(GameObject bullet)
    {
        float timeSinceLastFire = Time.time - _lastTimeFire;
        if (timeSinceLastFire > _timeBetweenShots)
        {
            for (int i = 0; i < FirePoints.Count; i++)
                FireBullet(bullet, FirePoints[i], _bulletSpeed);
            _lastTimeFire = Time.time;
            OnShipShoots?.Invoke(this, new OnShipShootsEventArgs
            {
                ShipTransform = gameObject.transform
            });
        }
    }
}
