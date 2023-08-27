using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpImage : MonoBehaviour
{
    [SerializeField] private GameObject _helpObjectToHide;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ShipMovements>())
            _helpObjectToHide.SetActive(false);
    }
}
