using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class LootCreation : MonoBehaviour
{
    public List<GameObject> LootCreatedHere = new List<GameObject>(2);
    private void Update()
    {
        if (gameObject.GetComponent<Statistics>().CurrentHealth <= 0)
            CreateLoot(transform);
    }
    protected void CreateLoot(Transform LootSpawn)
    {
        Instantiate(LootCreatedHere[Random.Range(0, LootCreatedHere.Count - 1)], LootSpawn.position, Quaternion.identity);
    }
}
