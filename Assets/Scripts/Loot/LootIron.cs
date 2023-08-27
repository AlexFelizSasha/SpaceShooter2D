using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootIron : MonoBehaviour
{
    public int IronAmountMaximum = 5;
    public int IronAmountMinimum = 2;

    private void Update()
    {
        Destroy(gameObject, 120f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBagage>())
        {
            int IronAmount = Random.Range(IronAmountMinimum, IronAmountMaximum);
            PlayerBagage _bagage = collision.GetComponent<PlayerBagage>();
            _bagage.Iron += IronAmount;
            Destroy(gameObject);
        }
    }
}