using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyValues
{
    public static int PlayerMaxHealth = 1000;
    public static int PlayerDamage = 60;
    public static int PlayerArmor = 25;

    public static int EnemyOneMaxHealth = 100;
    public static int EnemyOneDamage = 20;
    public static int EnemyOneArmor = 5;

    public static int EnemyTwoMaxHealth = 200;
    public static int EnemyTwoDamage = 30;
    public static int EnemyTwoArmor = 10;

    public static int EnemyThreeMaxHealth = 300;
    public static int EnemyThreeDamage = 40;
    public static int EnemyThreeArmor = 15;

    public static int EnemyAgressiveMaxHealth = 600;
    public static int EnemyAgressiveDamage = 60;
    public static int EnemyAgressiveArmor = 30;

    private static float[] _playerValues = { 1f, 1.25f, 1.5f };
    private static float[] _enemyValues = { 1f, 1.5f, 2f };
    private static int _enemiesAmount = 6;

    private static void SetStats(float difValuePlayer, float difValueEnemy)
    {
        PlayerMaxHealth = Mathf.RoundToInt(PlayerMaxHealth / difValuePlayer);
        PlayerDamage = Mathf.RoundToInt(PlayerDamage / difValuePlayer);
        PlayerArmor = Mathf.RoundToInt(PlayerArmor / difValuePlayer);

        EnemyOneMaxHealth = Mathf.RoundToInt(EnemyOneMaxHealth * difValueEnemy);
        EnemyOneDamage = Mathf.RoundToInt(EnemyOneDamage * difValueEnemy);
        EnemyOneArmor = Mathf.RoundToInt(EnemyOneArmor * difValueEnemy);

        EnemyTwoMaxHealth = Mathf.RoundToInt(EnemyTwoMaxHealth * difValueEnemy);
        EnemyTwoDamage = Mathf.RoundToInt(EnemyTwoDamage * difValueEnemy);
        EnemyTwoArmor = Mathf.RoundToInt(EnemyTwoArmor * difValueEnemy);

        EnemyThreeMaxHealth = Mathf.RoundToInt(EnemyThreeMaxHealth * difValueEnemy);
        EnemyThreeDamage = Mathf.RoundToInt(EnemyThreeDamage * difValueEnemy);
        EnemyThreeArmor = Mathf.RoundToInt(EnemyThreeArmor * difValueEnemy);

        EnemyAgressiveMaxHealth = Mathf.RoundToInt(EnemyAgressiveMaxHealth * difValueEnemy);
        EnemyAgressiveDamage = Mathf.RoundToInt(EnemyAgressiveDamage * difValueEnemy);
        EnemyAgressiveArmor = Mathf.RoundToInt(EnemyAgressiveArmor * difValueEnemy);

        _enemiesAmount = Mathf.RoundToInt(_enemiesAmount * difValueEnemy);

        Debug.Log("Stats are set");
    }
    public static void SetEasyStats()
    {
        SetStats(_playerValues[0], _enemyValues[0]);
    }
    public static void SetMediumStats()
    {
        SetStats(_playerValues[1], _enemyValues[1]);
    }
    public static void SetHardStats()
    {
        SetStats(_playerValues[2], _enemyValues[2]);
    }
    private static int[] TakeStatsForObject(int maxHealth, int maxDamage, int armor)
    {
        int[] stats = new int[3];
        stats[0] = maxHealth;
        stats[1] = maxDamage;
        stats[2] = armor;
        return stats;
    }
    public static int[] TakeStatsForPlayer()
    {
        return TakeStatsForObject(PlayerMaxHealth, PlayerDamage, PlayerArmor);
    }
    public static int[] TakeStatsForEnemyOne()
    {
        return TakeStatsForObject(EnemyOneMaxHealth, EnemyOneDamage, EnemyOneArmor);
    }
    public static int[] TakeStatsForEnemyTwo()
    {
        return TakeStatsForObject(EnemyTwoMaxHealth, EnemyTwoDamage, EnemyTwoArmor);
    }
    public static int[] TakeStatsForEnemyThree()
    {
        return TakeStatsForObject(EnemyThreeMaxHealth, EnemyThreeDamage, EnemyThreeArmor);
    }
    public static int[] TakeStatsForAgressiveEnemy()
    {
        return TakeStatsForObject(EnemyAgressiveMaxHealth, EnemyAgressiveDamage, EnemyAgressiveArmor);
    }
    public static int EnemiesAmount() { return _enemiesAmount; }
}
