using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptionsUI : MonoBehaviour
{
    public const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";
    public const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";

    [SerializeField] private Button _easyButton;

    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _soundEffectsSlider;

    private void Start()
    {
        _easyButton.Select();
        
        _volumeSlider.value = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, 0.5f);
        _soundEffectsSlider.value = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, 0.5f);

        _volumeSlider.onValueChanged.AddListener(delegate 
        { 
            SetVolume(_volumeSlider, PLAYER_PREFS_MUSIC_VOLUME); 
        });

        _soundEffectsSlider.onValueChanged.AddListener(delegate 
        { 
            SetVolume(_soundEffectsSlider, PLAYER_PREFS_SOUND_EFFECTS_VOLUME); 
        });
    }
    public void SetVolume(Slider slider, string prefsValue)
    {
        float volume = slider.value;
        Debug.Log(prefsValue + " is changed to " + volume);
        PlayerPrefs.SetFloat(prefsValue, volume);
        PlayerPrefs.Save();
    }
}
