using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplodes : ObjectExplodes
{
    public static event EventHandler<OnBulletExplodesEventArgs> OnBulletExplodes;
    public class OnBulletExplodesEventArgs : EventArgs
    {
        public Transform BulletTransform;
    }
    private Bullet _bullet;

    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
        _bullet.OnObjectExplodes += Bullett_OnObjectExplodes;
    }

    private void Bullett_OnObjectExplodes(object sender, IExplodable.OnObjectExplodesEventArgs e)
    {
        CreateExplode(e.ObjectTransform);

        OnBulletExplodes?.Invoke(this, new OnBulletExplodesEventArgs
        {
            BulletTransform = gameObject.transform
        });        
    }
}
