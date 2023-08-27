using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AsteroidExplodes : ObjectExplodes
{
    public static event EventHandler<OnAsteroidExplodesEventArgs> OnAsteroidExplodes;
    public class OnAsteroidExplodesEventArgs : EventArgs
    {
        public Transform AsteroidTransform;
    }
    private Statistics _asteroidStatistics;
    

    private void Awake()
    {
        _asteroidStatistics = GetComponent<Statistics>();
        _asteroidStatistics.OnObjectExplodes += AsteroidStatistics_OnObjectExplodes;
    }

    private void AsteroidStatistics_OnObjectExplodes(object sender, IExplodable.OnObjectExplodesEventArgs e)
    {
        CreateExplode(e.ObjectTransform);        
        OnAsteroidExplodes?.Invoke(this, new OnAsteroidExplodesEventArgs
        {
            AsteroidTransform = gameObject.transform
        });
    }
}
