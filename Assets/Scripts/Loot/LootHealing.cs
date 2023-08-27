using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHealing : MonoBehaviour
{
    public float HealthToAdd {  get; private set; }
 
    public void Awake()
    {
        HealthToAdd = 100;
    }
    private void Update()
    {
        Destroy(gameObject, 120f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerProgress>())
        {
            Statistics _statistics = collision.GetComponent<Statistics>();
            _statistics.CurrentHealth += HealthToAdd;
            if (_statistics.CurrentHealth > _statistics.MaxHealth)
                _statistics.CurrentHealth = _statistics.MaxHealth;
            Destroy(gameObject);
        }
    }
}
