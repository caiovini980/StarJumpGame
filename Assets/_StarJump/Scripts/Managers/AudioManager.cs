using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    
    [SerializeField] private AudioSource _gameOverSound;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private AudioSource _scoreSound;
    [SerializeField] private AudioSource _selectSource;
    
    [SerializeField] private AudioClip _selectSound;
    [SerializeField] private AudioClip _returnSound;
    [SerializeField] private AudioClip _highScoreSound;

    private UIManager _uiManager;
    
    private float _sfxVolume;
    private float _musicVolume;

    private const string VOLUME_SAVENAME = "volume";
    private const string SOUND_EFFECT_VOLUME_SAVENAME = "soundEffectsVolume";

    private void Start()
    {
        _audioMixer.SetFloat(VOLUME_SAVENAME, PlayerPrefs.GetFloat(VOLUME_SAVENAME, _musicVolume));
        _audioMixer.SetFloat(SOUND_EFFECT_VOLUME_SAVENAME, PlayerPrefs.GetFloat(SOUND_EFFECT_VOLUME_SAVENAME, _sfxVolume));

        _uiManager = GameManager.sInstance.UIManager;

        StartCoroutine(WaitToPlayThemeAndUpdateSliders(0.5f));
        
    }

    public void MusicTransition(float transitionTime)
    {
        _backgroundSound.volume = Mathf.Lerp(0.2f, 0f, transitionTime);
    }

    public void PlaySelectSound()
    {
        _selectSource.PlayOneShot(_selectSound);
    }
    
    public void PlayReturnSound()
    {
        _selectSource.PlayOneShot(_returnSound);
    }

    public void PlayHighScoreSound()
    {
        _scoreSound.PlayOneShot(_highScoreSound);
    }

    public void PlayGameOverSound()
    {
        _gameOverSound.Play();
    }
    
    public void SetVolume(float volume)
    {
        _musicVolume = volume;
        
        _audioMixer.SetFloat(VOLUME_SAVENAME, volume);
    }
    
    public void SetSoundEffectsVolume(float sfxVolume)
    {
        _sfxVolume = sfxVolume;
        
        _audioMixer.SetFloat(SOUND_EFFECT_VOLUME_SAVENAME, sfxVolume);
    }

    public void SaveAudioSettings()
    {
        PlayerPrefs.SetFloat(VOLUME_SAVENAME, _musicVolume);
        PlayerPrefs.SetFloat(SOUND_EFFECT_VOLUME_SAVENAME, _sfxVolume);
    }

    private IEnumerator WaitToPlayThemeAndUpdateSliders(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _uiManager.SetSlidersPositionTo(PlayerPrefs.GetFloat(VOLUME_SAVENAME, _musicVolume), 
            PlayerPrefs.GetFloat(SOUND_EFFECT_VOLUME_SAVENAME, _sfxVolume));
        
        _backgroundSound.Play();
    }
}
