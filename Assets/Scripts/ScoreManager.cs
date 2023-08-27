using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public static event EventHandler<OnScoreAddedEventArgs> OnScoreAdded;
    public class OnScoreAddedEventArgs : EventArgs
    {
        public int Score;
    }

    public const string PLAYER_PREFS_MAX_SCORE = "Max Score"; 
    private int _score;
    private void Awake()
    {
        Instance = this;
        _score = 0;
    }
    private void Start()
    {
        EnemyExplodes.OnEnemyExplodes += EnemyExplodes_OnEnemyExplodes;
        AsteroidExplodes.OnAsteroidExplodes += AsteroidExplodes_OnAsteroidExplodes;
        GameOverMenuUI.OnGameOverMenu += GameOverMenuUI_OnGameOverMenu;
    }

    private void GameOverMenuUI_OnGameOverMenu(object sender, EventArgs e)
    {
        SetMaxScore();
    }

    private void AsteroidExplodes_OnAsteroidExplodes(object sender, AsteroidExplodes.OnAsteroidExplodesEventArgs e)
    {
        int _scoreForAsteroid = 1;
        AddScore(_scoreForAsteroid);
    }

    private void EnemyExplodes_OnEnemyExplodes(object sender, EnemyExplodes.OnEnemyExplodesEventArgs e)
    {
        int _scoreToAdd = 0;
        if (e.EnemyTransform.gameObject.GetComponent<GiveEnemyOneStats>())
            _scoreToAdd = 5;
        if (e.EnemyTransform.gameObject.GetComponent<GiveEnemyTwoStats>())
            _scoreToAdd = 6;
        if (e.EnemyTransform.gameObject.GetComponent<GiveEnemyThreeStats>())
            _scoreToAdd = 7;
        if (e.EnemyTransform.gameObject.GetComponent<GiveAgressiveStats>())
            _scoreToAdd = 10;

        AddScore(_scoreToAdd);
    }
    private void AddScore(int scoreToAdd)
    {
        _score += scoreToAdd;

        Debug.Log("Score changes");

        OnScoreAdded?.Invoke(this, new OnScoreAddedEventArgs
        {
            Score = _score
        }) ;
    }
    private void SetMaxScore()
    {
        int _maxScore = PlayerPrefs.GetInt(PLAYER_PREFS_MAX_SCORE, 0);
        if (_maxScore < _score)
            _maxScore = _score;
        PlayerPrefs.SetInt(PLAYER_PREFS_MAX_SCORE, _maxScore);
        PlayerPrefs.Save();
    }
    public int GetCurrentScore()
    {
        return _score;
    }
    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt(PLAYER_PREFS_MAX_SCORE, 0);
    }
}
