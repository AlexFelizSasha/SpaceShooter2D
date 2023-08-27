using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialPageTwoUI : MonoBehaviour
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
