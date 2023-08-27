using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuUI : MonoBehaviour
{
    public static event EventHandler OnGameOverMenu;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _maxScoreText;
    [SerializeField] private Button _restart;
    

    private void OnEnable()
    {
        _restart.Select();
        SetCurrentScoreText();
        SetMaxScoreText();
        OnGameOverMenu?.Invoke(this, EventArgs.Empty);
    }
    private void SetCurrentScoreText()
    {
        _currentScoreText.text = "Your score: " + ScoreManager.Instance.GetCurrentScore().ToString();
    }
    private void SetMaxScoreText()
    {
        _maxScoreText.text = "Previous Max score: " + ScoreManager.Instance.GetMaxScore().ToString();
    }
}
