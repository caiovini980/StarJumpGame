using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _gameOverSound;
    [SerializeField] private AudioSource _backgroundSound;

    private void Start()
    {
        _backgroundSound.Play();
    }

    public void PlayGameOverSound()
    {
        _gameOverSound.Play();
    }
}
