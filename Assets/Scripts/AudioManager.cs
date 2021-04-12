using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _gameOverSound;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private AudioSource _scoreSound;
    [SerializeField] private AudioClip _highScore;

    private void Start()
    {
        _backgroundSound.Play();
    }

    public void PlayHighScoreSound()
    {
        _scoreSound.PlayOneShot(_highScore);
    }

    public void PlayGameOverSound()
    {
        _gameOverSound.Play();
    }
}
