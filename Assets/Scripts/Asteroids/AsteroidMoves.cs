using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMoves : MonoBehaviour
{
    public float asterSpeed = 0.3f;
    public float thisAsteroidSpeed;
    private int _randomSpeedAdd;

    private void Awake()
    {
        _randomSpeedAdd = Random.Range(1, 5);
    }
    void Update()
    {
        MoveAsteroid();
    }
    private void MoveAsteroid()
    {
        thisAsteroidSpeed = asterSpeed / (gameObject.GetComponent<Rigidbody2D>().mass) * _randomSpeedAdd;
        gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector3(2, -1, 0) * thisAsteroidSpeed);
    }
}
