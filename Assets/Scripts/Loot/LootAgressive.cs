using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootAgressive : LootCreation
{
    private void Update()
    {
        if (gameObject.GetComponent<Statistics>().CurrentHealth <= 0)
        for (int i = 0; i <= CountLootAmount();  i++) 
            CreateLoot(transform);
    }
    private int CountLootAmount()
    {
        float _livingTime = gameObject.GetComponent<Statistics>().LivingTime/60;
        int _livingTimeInt = Mathf.FloorToInt(_livingTime);
        return 1 + _livingTimeInt;
    }
}
