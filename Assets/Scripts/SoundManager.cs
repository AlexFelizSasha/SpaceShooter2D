using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundEffectsSO _soundEffectsSO;
    public static SoundManager Instance { get; private set; }

    private AudioSource _audioSource;

    private static float _effectsVolume;

    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        SetMusicVolumeLevel(PlayerPrefs.GetFloat(MenuOptionsUI.PLAYER_PREFS_MUSIC_VOLUME));
        SetEffectsVolumeLevel(PlayerPrefs.GetFloat(MenuOptionsUI.PLAYER_PREFS_SOUND_EFFECTS_VOLUME));
    }
    private void Start()
    {
        PlayerShoots.OnShipShoots += ShipShoots_OnShipShoots;
        EnemyShoot.OnShipShoots += ShipShoots_OnShipShoots;
        BulletExplodes.OnBulletExplodes += BulletExplodes_OnBulletExplodes;
        EnemyExplodes.OnEnemyExplodes += EnemyExplodes_OnEnemyExplodes;
        AsteroidExplodes.OnAsteroidExplodes += AsteroidExplodes_OnAsteroidExplodes;
    }

    private void AsteroidExplodes_OnAsteroidExplodes(object sender, AsteroidExplodes.OnAsteroidExplodesEventArgs e)
    {
        PlaySound(_soundEffectsSO.AsteroidExplode, e.AsteroidTransform.position);
    }

    private void EnemyExplodes_OnEnemyExplodes(object sender, EnemyExplodes.OnEnemyExplodesEventArgs e)
    {
        PlaySound(_soundEffectsSO.EnemyExplode, e.EnemyTransform.position);
    }

    private void BulletExplodes_OnBulletExplodes(object sender, BulletExplodes.OnBulletExplodesEventArgs e)
    {
        float volumeFixed = 0.5f;
        PlaySound(_soundEffectsSO.BulletExplode, e.BulletTransform.position, volumeFixed);
    }
    private void ShipShoots_OnShipShoots(object sender, PlayerShoots.OnShipShootsEventArgs e)
    {
        float volumeFixed = 0.3f;
        PlaySound(_soundEffectsSO.ShipShoots, e.ShipTransform.position, volumeFixed);
    }

    private void SetMusicVolumeLevel(float volumeLevel)
    {
        _audioSource.volume = volumeLevel;
    }
    private void SetEffectsVolumeLevel(float volumeLevel)
    {
        _effectsVolume = volumeLevel;
    }
    public static void PlaySound(AudioClip audioClip, Vector3 position, float extraVolume = 1)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, _effectsVolume * extraVolume);
    }
}
