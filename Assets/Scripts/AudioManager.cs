using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _gameOverSound;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private AudioSource _scoreSound;
    [SerializeField] private AudioSource _selectSource;
    
    [SerializeField] private AudioClip _selectSound;
    [SerializeField] private AudioClip _returnSound;
    [SerializeField] private AudioClip _highScoreSound;

    private void Start()
    {
        _backgroundSound.Play();
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
}
