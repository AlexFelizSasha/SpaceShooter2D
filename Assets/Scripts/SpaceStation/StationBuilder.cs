using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationBuilder : MonoBehaviour
{
    public int StationLevel = 0;
    public int LevelUpAmount = 1;

    public GameObject Workshop;

    private void Update()
    {
        LevelUpStation();
    }
    private void LevelUpStation()
    {
        WorkShop _workShop = Workshop.gameObject.GetComponent<WorkShop>();
        if (_workShop.BuildingResource >= ResourceForLVLup())
        {
            _workShop.BuildingResource -= ResourceForLVLup();
            StationLevel++;
        }
    }
    private int ResourceForLVLup()
    {
        return LevelUpAmount; 
    }
}
