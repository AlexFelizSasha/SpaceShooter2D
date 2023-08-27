using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static EnemyExplodes;

public class EnemyExplodes : ObjectExplodes
{
    public static event EventHandler<OnEnemyExplodesEventArgs> OnEnemyExplodes;
    public class OnEnemyExplodesEventArgs : EventArgs
    {
        public Transform EnemyTransform;
    }
    private Statistics _enemyStatistics;

    private void Awake()
    {
        _enemyStatistics = GetComponent<Statistics>();
        _enemyStatistics.OnObjectExplodes += EnemyStatistics_OnObjectExplodes;
    }

    private void EnemyStatistics_OnObjectExplodes(object sender, IExplodable.OnObjectExplodesEventArgs e)
    {
        CreateExplode(e.ObjectTransform);
        //SoundManager.PlaySound(_enemyStatistics.ExplodeSound, e.ObjectTransform.position);
        OnEnemyExplodes?.Invoke(this, new OnEnemyExplodesEventArgs
        {
            EnemyTransform = gameObject.transform
        });
    }
}
