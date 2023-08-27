using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GivePlayerStats : MonoBehaviour
{
    protected Statistics _statistics;
    protected int[] _statsValues;

    private void Awake()
    {
        _statsValues = DifficultyValues.TakeStatsForPlayer();
        _statistics = GetComponent<Statistics>();

        ChangeStatsWithDifficulty(_statsValues[0], _statsValues[1], _statsValues[2]);
        Debug.Log("GivePlayerStats Awake method called");
    }

    protected void ChangeStatsWithDifficulty(int maxHealth, int damage, int armor)
    {
        _statistics.MaxHealth = maxHealth;
        _statistics.CurrentHealth = maxHealth;
        _statistics.Damage = damage;
        _statistics.Armor = armor;
        Debug.Log($"{gameObject.name} now has {_statistics.MaxHealth} MaxHealth, {_statistics.Damage} Damage, and {_statistics.Armor} Armor");
    }
}
