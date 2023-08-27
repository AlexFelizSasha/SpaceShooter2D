using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Transform _respawnPoint;
    private void Awake()
    {
        RespawnPlayer();
    }
    private void RespawnPlayer()
    {
        Instantiate(_player, _respawnPoint.position, transform.rotation);
    }
}
