using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialPageOneUI : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;

    private void Start()
    {
        _mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}
