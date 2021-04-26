using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnimationController : MonoBehaviour
{
    private Animator _animator;
    
    private const string PAUSE_PARAM_NAME = "hasPaused";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayPauseAnimation()
    {
        _animator.enabled = true;
        _animator.SetBool(PAUSE_PARAM_NAME, true);
    }
    
    public void PlayClosePauseAnimation()
    {
        _animator.enabled = true;
        _animator.SetBool(PAUSE_PARAM_NAME, false);
    }
}
