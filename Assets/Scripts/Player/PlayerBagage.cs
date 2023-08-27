using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBagage : MonoBehaviour
{
    public float Instruments;
    public float Iron;
    public float Coal;

    public float InstrumentsMax;
    public float IronMax;
    public float CoalMax;

    private float _healthLevelToDestroy = 0.05f;

    private void Awake()
    {
        InstrumentsMax = 10;
        IronMax = 30;
        CoalMax = 50;        
    }
    private void Update()
    {
        if (gameObject.GetComponent<PlayerProgress>().LvlIsUp)
            EnlargeBaggageSize();
        if (gameObject.GetComponent<Statistics>().CountHealthPercentage() <= _healthLevelToDestroy)
            DestroyBaggage();
        ControlBaggageSize();
    }
    public void DestroyBaggage()
    {
        Instruments = 0;
        Iron = 0;
        Coal = 0;
    }
    public void EnlargeBaggageSize()
    {
        InstrumentsMax += 1;
        IronMax += 10;
        CoalMax += 20;
    }
    protected void ControlBaggageSize()
    {
        if (Instruments > InstrumentsMax)
            Instruments = InstrumentsMax;
        if (Iron > IronMax)
            Iron = IronMax;
        if (Coal > CoalMax)
            Coal = CoalMax;
    }
}
