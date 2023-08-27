using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerShoots : ShipShoots
{
    private void Awake()
    {
        _bulletPool = GetComponent<BulletPool>();
    }
    private void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            GameObject _bullet = _bulletPool.GetPooledObject();
            FireAllBullets(_bullet);            
        }
    }
}
