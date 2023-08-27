using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public float CurrentExperience;
    public int CurrentLVL = 0;
    public int MaxLVL = 15;
    public bool LvlIsUp = false;

    private List<float> _experienceForLVLup = new List<float>();
    private List<float> _maxHealthForEachLVL = new List<float>();
    private List<float> _damageForEachLVL = new List<float>();
    private List<float> _armorForEachLVL = new List<float>();
    private Statistics statistics;
    private float _maxHealth;
    private float _damage;
    private float _armor;

    private float _minimumExperience = 500;
    private float _maxHealthGrowth = 100;
    private float _damageGrowth = 10;
    private float _armorGrowth = 2;

    private void Awake()
    {
        CountExperienceForLVL();
        CountStaticsLists();
        CurrentExperience = 0;
        statistics = gameObject.GetComponent<Statistics>();
        _maxHealth = statistics.MaxHealth;
        _damage = statistics.Damage;
        _armor = statistics.Armor;
    }
    private void Update()
    {
        LvlIsUp = false;
        if (CurrentExperience >= _experienceForLVLup[CurrentLVL])
        {
            RaiseLevel(CurrentLVL);
            ChangeStatistics(CurrentLVL);
            LvlIsUp = true;
        }

    }
    public void RaiseLevel(int level)
    {
        if (CurrentLVL <= MaxLVL)
        {
            CurrentExperience -= _experienceForLVLup[level];
            CurrentLVL += 1;
        }
    }
    private void CountExperienceForLVL()
    {
        for (int i = 0; i <= MaxLVL - 1; i++)
        {
            float _currentExperience;
            if (i < 5)
                _currentExperience = _minimumExperience * (float)Mathf.Pow(1.7f, i);
            else
                if (i > 5 && i < 10)
                _currentExperience = _experienceForLVLup[i - 1] * 2;
            else
                _currentExperience = _experienceForLVLup[i - 1] * 1.4f;
            _experienceForLVLup.Add(_currentExperience);
            Debug.Log($"Experience for LVL{i + 1} is {_currentExperience}");
        }
    }
    private void ChangeStatistics(int level)
    {
        statistics.MaxHealth += _maxHealthForEachLVL[level];
        statistics.Damage += _damageForEachLVL[level];
        statistics.Armor += _armorForEachLVL[level];
        if (statistics.Armor >= 80)
            statistics.Armor = 80;
    }
    private void CountStaticsLists()
    {
        for (int i = 0; i < MaxLVL; i++)
        {
            _maxHealthForEachLVL.Add(i * _maxHealthGrowth);
            _damageForEachLVL.Add(i * _damageGrowth);
            _armorForEachLVL.Add(i * _armorGrowth);
        }
    }
    public float CountExperiencePercentage()
    {
        if (CurrentExperience > 0)
        {
            float _currentExperiencePercent = CurrentExperience / _experienceForLVLup[CurrentLVL];
            return _currentExperiencePercent;
        }
        else return 0;
    }
}
