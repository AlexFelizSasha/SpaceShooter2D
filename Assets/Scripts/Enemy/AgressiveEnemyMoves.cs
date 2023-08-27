using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveEnemyMoves : EnemyMoves
{
    private void Awake()
    {
        _enemyBody = GetComponent<Rigidbody2D>();
        _enemyPlayerDistance = GetComponent<EnemyPlayerDistance>();
    }
    private void FixedUpdate()
    {
        AlwaysLookAtPlayer();
        RotateTowardsTarget();
        SetVelocity();
    }
    private void AlwaysLookAtPlayer()
    {
        _fireDirection = _enemyPlayerDistance.DirectionToPlayer;
    }

}
