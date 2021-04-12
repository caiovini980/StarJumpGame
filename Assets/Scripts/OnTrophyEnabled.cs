using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrophyEnabled : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameManager.sInstance.AudioManager;
    }

    private void OnEnable()
    {
        LeanTween.scale(gameObject, new Vector3(2f, 2f, 1f), 0.4f).setOnComplete(ReturnToNormalSize);
        
        _audioManager.PlayHighScoreSound();
    }

    private void ReturnToNormalSize()
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.2f);
    }
}
