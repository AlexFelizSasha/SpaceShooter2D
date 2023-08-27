using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    protected float _speed = 0.2f;
    protected float _rotationSpeed = 50;

    protected Rigidbody2D _enemyBody;
    protected EnemyPlayerDistance _enemyPlayerDistance;
    protected Vector2 _fireDirection;
    protected float _timeToChangeDirection;
    protected Vector2 _distanceToObject;
    protected float _distanceToDodge = 0.3f;
    protected Transform _objectToDodgeFrom;

    private void Awake()
    {
        _objectToDodgeFrom = FindObjectOfType<Statistics>().transform;
        _enemyBody = GetComponent<Rigidbody2D>();
        _enemyPlayerDistance = GetComponent<EnemyPlayerDistance>();
        _fireDirection = transform.up;
    }

    private void FixedUpdate()
    {
        //Dodge();
        UpdateFireDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    protected void UpdateFireDirection()
    {
        CreateRandomDirection(Random.Range(10f, 15f));
        LookAtPlayer();
    }

    protected void RotateTowardsTarget()
    {

        Quaternion rotationEnemy = Quaternion.LookRotation(transform.forward, _fireDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, rotationEnemy, _rotationSpeed * Time.deltaTime);
        _enemyBody.SetRotation(rotation);
    }

    protected void SetVelocity()
    {
        _enemyBody.velocity = transform.up * _speed;
    }

    protected void CreateRandomDirection(float timeToChange)
    {
        _timeToChangeDirection -= Time.deltaTime;
        if (_timeToChangeDirection <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _fireDirection = rotation * _fireDirection;
            _timeToChangeDirection = timeToChange;
        }
    }
    protected void LookAtPlayer()
    {
        if (_enemyPlayerDistance.IfPlayerClose)
            _fireDirection = _enemyPlayerDistance.DirectionToPlayer;
    }
    protected void Dodge()
    {
        if (_objectToDodgeFrom.position != transform.position)
        {
            Vector2 _vectorToObject = _objectToDodgeFrom.position - transform.position;
            _distanceToObject = _vectorToObject.normalized;
            if (_distanceToObject.magnitude <= _distanceToDodge)
                CreateRandomDirection(1f);
        }
    }
}
