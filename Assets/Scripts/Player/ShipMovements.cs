using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using System;

public class ShipMovements : MonoBehaviour
{
    private float _angleRotate;
    [SerializeField] private float _speedMove = 0;
    [SerializeField] private GameObject _engineFire;

    private Rigidbody2D _playerBody;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _engineFire.SetActive(false);
    }
    private void Update()
    {
        MoveTheShip();
        ControlTheShip();
        ControlEngineFire();
    }
    private void ControlEngineFire()
    {
        _engineFire.SetActive(_speedMove > 0);
    }
    private void RotateLeft()
    {
        _angleRotate += 1.5f;
        transform.localEulerAngles = new Vector3(0, 0, _angleRotate);
    }
    private void RotateRight()
    {
        _angleRotate -= 1.5f;
        transform.localEulerAngles = new Vector3(0, 0, _angleRotate);
    }

    private void SpeedUp()
    {
        if (_speedMove < 5f)
            _speedMove += 0.2f;
    }
    private void SpeedDown()
    {
        _speedMove -= 0.3f;
        if (_speedMove < 0)
            _speedMove = 0;
    }
    private void MoveTheShip()
    {
        _playerBody.velocity = gameObject.transform.up * _speedMove;
    }
    private void ControlTheShip()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
            RotateLeft();
        if (Keyboard.current.rightArrowKey.isPressed)
            RotateRight();
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
            SpeedUp();
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
            SpeedDown();
    }
}
