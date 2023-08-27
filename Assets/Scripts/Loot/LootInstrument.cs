using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootInstrument : MonoBehaviour
{
    public int InstrumentAmountMaximum = 3;
    public int InstrumentAmountMinimum = 1;

    private void Update()
    {
        Destroy(gameObject, 120f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBagage>())
        {
            int InstrumentAmount = Random.Range(InstrumentAmountMinimum, InstrumentAmountMaximum);
            PlayerBagage _bagage = collision.GetComponent<PlayerBagage>();
            _bagage.Instruments += InstrumentAmount;
            Destroy(gameObject);
        }            
    }
}


