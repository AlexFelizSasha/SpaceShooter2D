using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Statistics _statistics;
    private GameObject _player;
    [SerializeField]
    private UnityEngine.UI.Image _healthBarImage;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerProgress>().gameObject;
        _statistics = _player.GetComponent<Statistics>();
        UpdateHealthBar(TakeHealthPercentage());
    }
    private void Update()
    {
        UpdateHealthBar(TakeHealthPercentage());
    }

    public float TakeHealthPercentage()
    {
        float _healthPercentage = _statistics.CountHealthPercentage();
        return _healthPercentage;
    }
    private void UpdateHealthBar(float fillAmount)
    {
        _healthBarImage.fillAmount = fillAmount;
    }

}
