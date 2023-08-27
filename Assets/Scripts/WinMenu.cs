using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private GameObject _winMenu;

    private void Start()
    {
        _continueButton.onClick.AddListener(() =>
        {
            Destroy(_winMenu.gameObject);
        });
    }
}
