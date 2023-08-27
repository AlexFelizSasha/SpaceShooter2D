using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCollides : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
            gameObject.GetComponentInParent<Statistics>().CurrentHealth -= (collision.gameObject.GetComponent<Statistics>().Damage * (100 - gameObject.GetComponentInParent<Statistics>().Armor) / 100);
        else
        if (collision.tag == "LootHealing")
        {
            gameObject.GetComponentInParent<Statistics>().CurrentHealth += collision.gameObject.GetComponent<LootHealing>().HealthToAdd;
            Debug.Log("Player is healed with 100");
        }
        else
            if ((collision.tag == "Steroid") || (collision.tag == "Planet"))
            gameObject.GetComponentInParent<Statistics>().CurrentHealth -= (10 * (100 - gameObject.GetComponentInParent<Statistics>().Armor) / 100);
    }
}
