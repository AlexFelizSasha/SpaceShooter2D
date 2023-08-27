using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameZoneCollisions : MonoBehaviour
{
    [SerializeField]
    private AsteroidsPool _pool;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Statistics statistics = collision.gameObject.GetComponent<Statistics>();
        if (collision.gameObject.GetComponent<AsteroidMoves>())
            statistics.CurrentHealth = 0;
        else statistics.CurrentHealth -= 50;
    }
}
