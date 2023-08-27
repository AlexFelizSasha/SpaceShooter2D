using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceBar : MonoBehaviour
{
    private PlayerProgress _progress;
    private GameObject _player;
    [SerializeField]
    private UnityEngine.UI.Image _expBarImage;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerProgress>().gameObject;
        _progress = _player.GetComponent<PlayerProgress>();
        UpdateExpBar(TakeExperiencePercentage());
    }
    private void Update()
    {
        UpdateExpBar(TakeExperiencePercentage());
    }

    public float TakeExperiencePercentage()
    {
        float _expPercentage = _progress.CountExperiencePercentage();
        return _expPercentage;
    }
    private void UpdateExpBar(float fillAmount)
    {
        _expBarImage.fillAmount = fillAmount;
    }
}
