using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText.text = "Score: 0";
        ScoreManager.OnScoreAdded += ScoreManager_OnScoreAdded;
    }

    private void ScoreManager_OnScoreAdded(object sender, ScoreManager.OnScoreAddedEventArgs e)
    {
        int _score = e.Score;
        
        _scoreText.text = "Score: " + _score.ToString();
    }
}
