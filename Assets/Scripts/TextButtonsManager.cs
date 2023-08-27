using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TextButtonsManager : MonoBehaviour
{
    public TMP_Text HealthPercentageText;
    public TMP_Text HealthAmountText;
    public TMP_Text ExperiencePercentageText;
    public TMP_Text InstrumentResourceText;
    public TMP_Text CoalResourceText;
    public TMP_Text IronResourceText;
    public TMP_Text WorkShopInstrumentText;
    public TMP_Text WorkShopCoalText;
    public TMP_Text WorkShopIronText;
    public TMP_Text WorkShopBuilderText;
    public TMP_Text PlayerLVLText;
    public TMP_Text StationLVLText;
    public Image HealthBarImage;
    public Image ExperienceBarImage;
    public GameObject GameOverMenu;
    public GameObject MenuInGame;
    public GameObject Player;
    public GameObject WorkShop;
    public GameObject StationBuilding;

    private TMP_Text[] _workShopResources = new TMP_Text[3];
    private TMP_Text[] _bagageResources = new TMP_Text[3];
    private Statistics _statistics;
    private PlayerProgress _progress;
    private PlayerBagage _playerBagage;
    private WorkShop _workShopBagage;
    private StationBuilder _stationBuilder;
    private float _health;
    private float _experience;
    private void Start()
    {
        _statistics = Player.GetComponent<Statistics>();
        _progress = Player.GetComponent<PlayerProgress>();
        _playerBagage = Player.GetComponent<PlayerBagage>();
        _workShopBagage = WorkShop.GetComponent<WorkShop>();
        _stationBuilder = StationBuilding.GetComponent<StationBuilder>();
    }
    private void Update()
    {
        _health = _statistics.CountHealthPercentage();
        
        _experience = _progress.CountExperiencePercentage();

        ShowPercentage(_health, HealthPercentageText);
        ShowPercentage(_experience, ExperiencePercentageText);

        ShowAllResources(_playerBagage, BagageStock());
        ShowAllResources(_workShopBagage, WorkShopStock());

        ShowResources(_workShopBagage.BuildingResource, 0, WorkShopBuilderText);

        UpdateBar(_health, HealthBarImage);
        UpdateBar(_experience, ExperienceBarImage);

        ShowStationLevel();
        ShowPlayerLevel();

        ShowHealthAmount();

        ShowIfGameOver();
        ShowMenuInGame();
    }
    private TMP_Text[] WorkShopStock()
    {
        _workShopResources[0] = WorkShopInstrumentText;
        _workShopResources[1] = WorkShopIronText;
        _workShopResources[2] = WorkShopCoalText;
        return _workShopResources;
    }
    private TMP_Text[] BagageStock()
    {
        _bagageResources[0] = InstrumentResourceText;
        _bagageResources[1] = IronResourceText;
        _bagageResources[2] = CoalResourceText;
        return _bagageResources;
    }
    private void ShowHealthAmount()
    {
        int _healthAmount = Mathf.RoundToInt(_statistics.CurrentHealth);
        HealthAmountText.text = _healthAmount.ToString();
    }

    private void ShowPercentage(float statToShow, TMP_Text StatisticText)
    {
        float percent = (float)System.Math.Round(statToShow * 100, 2);
        StatisticText.text = percent.ToString() + "%";
    }
    private void ShowResources(float resourceToShow, float maxResource, TMP_Text ResourcesText)
    {
        if (maxResource == 0)
            ResourcesText.text = resourceToShow.ToString();
        else ResourcesText.text = resourceToShow.ToString() + "/" + maxResource.ToString();
    }
    private void ShowAllResources(PlayerBagage stock, TMP_Text[] stockText)
    {
        ShowResources(stock.Instruments, stock.InstrumentsMax, stockText[0]);
        ShowResources(stock.Iron, stock.IronMax, stockText[1]);
        ShowResources(stock.Coal, stock.CoalMax, stockText[2]);
    }
    private void UpdateBar(float fillAmount, Image barToUpdate)
    {
        barToUpdate.fillAmount = fillAmount;
    }
    private void ShowIfGameOver()
    {
        if (!Player.gameObject.activeInHierarchy)
        {
            GameOverMenu.SetActive(true);
        }
    }
    private void ShowMenuInGame()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            MenuInGame.SetActive(true);
    }
    public void ClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ClickMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowStationLevel()
    {
        int _stationLevel = _stationBuilder.StationLevel;
        StationLVLText.text = "Station LVL - " + _stationLevel.ToString();
    }
    public void ShowPlayerLevel()
    {
        int _playerLevel = _progress.CurrentLVL;
        PlayerLVLText.text = "Player LVL - " + _playerLevel.ToString();
    }
}
