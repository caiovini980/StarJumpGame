using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Animator _playerAnimator;

    private string _currentState;
    
    private const string JUMP_ANIM_NAME = "JumpAnim";

    private void Awake()
    {
        _playerAnimator = _player.GetComponent<Animator>();
    }
    
    public void PlayPlayerJumpAnimation()
    {
        _playerAnimator.Play(JUMP_ANIM_NAME, -1, 0);
        _playerAnimator.Play(JUMP_ANIM_NAME);
    }
}
