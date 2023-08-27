using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationWeaponStats : MonoBehaviour
{
    public GameObject StationBuilderObject;
    public float Damage;
    private float _startDamage = 100;

    private void Update()
    {
        Damage = StationDamage(StationLevel());
    }

    private int StationLevel()
    {
        StationBuilder _station_builder = StationBuilderObject.GetComponent<StationBuilder>();
        return _station_builder.StationLevel;
    }
    public float StationDamage(int stationLevel)
    {
        return _startDamage * (stationLevel + 1);
    }
}
