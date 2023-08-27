using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveEnemyThreeStats : GivePlayerStats
{
    private void Awake()
    {
        _statsValues = DifficultyValues.TakeStatsForEnemyThree();
        _statistics = GetComponent<Statistics>();
        ChangeStatsWithDifficulty(_statsValues[0], _statsValues[1], _statsValues[2]);
    }
}
