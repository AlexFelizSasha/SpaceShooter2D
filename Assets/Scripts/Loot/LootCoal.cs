using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCoal : MonoBehaviour
{
    public int CoalAmountMaximum = 6;
    public int CoalAmountMinimum = 3;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBagage>())
        {
            int CoalAmount = Random.Range(CoalAmountMinimum, CoalAmountMaximum);
            PlayerBagage _bagage = collision.GetComponent<PlayerBagage>();
            _bagage.Coal += CoalAmount;
            Destroy(gameObject);
        }
    }
}
