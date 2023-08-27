using System.Collections;
using UnityEngine;


public class ObjectsCollides : MonoBehaviour
{
    private bool _collisionTime;
    public float _collidingDamage { get; private set; }
    private float _collidingAdditionalDamage = 10;
    private Statistics _statistics;
    private void Awake()
    {
        _collisionTime = true;
        _statistics = gameObject.GetComponent<Statistics>();
        StartCoroutine(CountTimeForColliding());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            Debug.Log($"{gameObject.name} is Shot!");
            float _bulletDamage = collision.gameObject.GetComponent<Bullet>().Damage;
            float _armor = _statistics.Armor;
            _collidingDamage = _bulletDamage - _bulletDamage * _armor / 100;
            _statistics.CurrentHealth -= _collidingDamage;
        }
    }
    private void CountCollideDamage(Collision2D collidingObject)
    {
        float _collidingObjectSpeed = 0;
        if (collidingObject.gameObject.GetComponent<Statistics>())
            _collidingObjectSpeed = collidingObject.gameObject.GetComponent<Statistics>().Speed;

        float _collidingObjectMass = 1;
        if(collidingObject.gameObject.GetComponent<Rigidbody2D>())
            _collidingObjectMass = collidingObject.gameObject.GetComponent<Rigidbody2D>().mass;

        float _objectSpeed = _statistics.Speed;

        _collidingDamage = (_collidingObjectSpeed + _objectSpeed) * _collidingObjectMass * _collidingAdditionalDamage;
        _statistics.CurrentHealth -= _collidingDamage;
        Debug.Log($"{gameObject.name} has got {_collidingDamage} damage after colliding with {collidingObject.gameObject.name}!");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_collisionTime)
        {
            if (collision.gameObject.GetComponent<AsteroidMoves>() || collision.gameObject.GetComponent<EnemiesPool>())
            {
                _collisionTime = false;
                _collidingDamage = 30;
                _statistics.CurrentHealth -= _collidingDamage;
            }
            else
            {
                _collisionTime = false;
                CountCollideDamage(collision);
            }
        }
    }
    IEnumerator CountTimeForColliding()
    {
        yield return new WaitForSeconds(3f);
        _collisionTime = true;
    }
}