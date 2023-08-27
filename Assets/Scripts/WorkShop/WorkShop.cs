using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkShop : PlayerBagage
{    
    private float _instrumentsForUpdateMaterial = 1;
    private float _ironForUpdateMaterial = 3;
    private float _coalForUpdateMaterial = 4;

    public int BuildingResource;
    private void Awake()
    {
        BuildingResource = 0;
    }
    private void Update()
    {
        ProduceBuildingResource();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBagage>())
        {
            PlayerBagage _playerBagage = collision.gameObject.GetComponent<PlayerBagage>();
            TakeBagage(_playerBagage);
            HealPlayer(collision.gameObject);
        }
    }
    private void TakeBagage(PlayerBagage playerBagage)
    {
        Coal += playerBagage.Coal;
        Instruments += playerBagage.Instruments;
        Iron += playerBagage.Iron;
        playerBagage.DestroyBaggage();
    }
    public void GiveResources(float instruments = 0, 
                              float iron = 0, 
                              float coal = 0)
    {
        Instruments -= instruments;
        Iron -= iron;
        Coal -= coal;
    }
    public void HealPlayer(GameObject player)
    {
        Statistics _playerStatistics = player.gameObject.GetComponent<Statistics>();
        _playerStatistics.CurrentHealth = _playerStatistics.MaxHealth;
    }
    private void ProduceBuildingResource()
    {
        if (_instrumentsForUpdateMaterial <= Instruments && _coalForUpdateMaterial <= Coal && _ironForUpdateMaterial <= Iron)
        {
            GiveResources(_instrumentsForUpdateMaterial, _ironForUpdateMaterial, _coalForUpdateMaterial);
            BuildingResource++;
        }
    }
}
