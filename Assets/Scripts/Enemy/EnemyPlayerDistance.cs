using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDistance : MonoBehaviour
{
    public bool IfPlayerClose { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    private float _distanceToFirePlayer = 10f;
    private Transform _player;

    void Awake()
    {
        _player = FindObjectOfType<PlayerProgress>().transform;
    }

    void Update()
    {
        CountVectorToPlayer();
    }
    private void CountVectorToPlayer()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _distanceToFirePlayer)
            IfPlayerClose = true;
        else
            IfPlayerClose = false;
    }
}
