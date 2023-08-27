using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectExplodes : MonoBehaviour
{
    [SerializeField] protected GameObject _explodePrefab;
     protected void CreateExplode(Transform explodePosition)
    {
        GameObject _explode = Instantiate(_explodePrefab, explodePosition.position, Quaternion.identity);
        Destroy(_explode, 1f);
    }
}
