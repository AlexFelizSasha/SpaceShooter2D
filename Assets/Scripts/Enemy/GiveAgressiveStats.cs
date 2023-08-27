using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAgressiveStats : GivePlayerStats
{    private void Awake()
    {
        _statsValues = DifficultyValues.TakeStatsForAgressiveEnemy();
        _statistics = GetComponent<Statistics>();
        ChangeStatsWithDifficulty(_statsValues[0], _statsValues[1], _statsValues[2]);
    }
}
