using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationProgress : MonoBehaviour
{
    public GameObject MainBody;
    public GameObject WeaponBuilder;
    public GameObject Turret1;
    public GameObject Turret2;
    public GameObject Shield;
    public GameObject StationBuilderHere;
    [SerializeField] private GameObject _winMenu;
    void Update()
    {
        GrowStation(StationLevel());
    }
    private void GrowStation(int stationLevel)
    {
        switch (stationLevel)
        {
            case 0: break;
            case 1:
                MainBody.SetActive(true);
                break;
            case 2:
                WeaponBuilder.SetActive(true);
                break;
            case 3:
                Turret1.SetActive(true);
                break;
            case 4:
                Turret2.SetActive(true);
                break;
            case 5:
                Shield.SetActive(true);
                if (_winMenu != null)
                    _winMenu.gameObject.SetActive(true);
                break;
            default:

                break;
        }
    }
    private int StationLevel()
    {
        StationBuilder _stationBuilder = StationBuilderHere.GetComponent<StationBuilder>();
        return _stationBuilder.StationLevel;
    }
}
