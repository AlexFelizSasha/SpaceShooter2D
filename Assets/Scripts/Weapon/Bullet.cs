using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour, IExplodable
{
    [SerializeField] private float _damage = 10;
    [SerializeField] public AudioClip BulletExplodesAudio;

    public event EventHandler<IExplodable.OnObjectExplodesEventArgs> OnObjectExplodes;
    public class OnObjectExplodesEventArgs : EventArgs
    {
        public Transform ObjectTransform;
    }

    private float _livingTime;
    private float _timeToDestroy = 4f;
    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }

    private void OnEnable()
    {
        _livingTime = 0;
    }
    private void Update()
    {
        _livingTime += Time.deltaTime;
        if (_livingTime > _timeToDestroy)
        {
            gameObject.SetActive(false);            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer)
        {
            gameObject.SetActive(false);

            OnObjectExplodes?.Invoke(this, new IExplodable.OnObjectExplodesEventArgs
            {
                ObjectTransform = transform
            });
        }
    }
    public void SetDamage(float damage)
    {
        _damage += damage;
    }
}
