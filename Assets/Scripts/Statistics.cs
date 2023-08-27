using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Statistics : MonoBehaviour, IExplodable
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth = 100;
    [SerializeField] private float damage;
    [SerializeField] private float armor;

    public event EventHandler<IExplodable.OnObjectExplodesEventArgs> OnObjectExplodes;
    public class OnObjectExplodesEventArgs : EventArgs
    {
        public Transform ObjectTransform;
    }

    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }
    public float CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }
    public float Damage
    {
        get => damage;
        set => damage = value;
    }
    public float Armor
    {
        get => armor;
        set => armor = value;
    }
    public float Speed { get; private set; }
    public float LivingTime { get; private set; }
    private void OnEnable()
    {
        CurrentHealth = MaxHealth;
        LivingTime = 0;
    }

    private void FixedUpdate()
    {
        StartCoroutine(CountSpeed());
        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            LivingTime += Time.time;

            OnObjectExplodes?.Invoke(this, new IExplodable.OnObjectExplodesEventArgs
            {
                ObjectTransform = transform
            });
        }
    }
    IEnumerator CountSpeed()
    {
        Vector3 previousPosition = gameObject.transform.position;
        yield return new WaitForFixedUpdate();
        Speed = (float)System.Math.Round(((gameObject.transform.position - previousPosition).magnitude / Time.fixedDeltaTime), 3);
    }
    public float CountHealthPercentage()
    {
        float _currentHealth = CurrentHealth;
        float _maxHealth = MaxHealth;
        float _healthPercentage = _currentHealth / _maxHealth;
        return _healthPercentage;
    }
}
