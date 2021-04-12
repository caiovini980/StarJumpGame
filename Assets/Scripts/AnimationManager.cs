using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _darkScreenUI;
    [SerializeField] private ParticleSystem _playerParticle;
    [SerializeField] private ParticleSystem _breakableParticle;
    [SerializeField] private ParticleSystem _boostParticle;

    private Animator _playerAnimator;
    private Animator _darkScreenAnimator;

    private string _currentState;
    
    private const string JUMP_ANIM_NAME = "JumpAnim";
    private const string DARKFADE_ANIM_NAME = "Fade";

    private void Awake()
    {
        _playerAnimator = _player.GetComponent<Animator>();
        _darkScreenAnimator = _darkScreenUI.GetComponent<Animator>();
    }

    public void PlayPlayerParticleSystemAt(Vector2 position)
    {
        _playerParticle.transform.position = position;
        _playerParticle.Play();
    }
    
    public void PlayBoostParticleSystemAt(Vector2 position)
    {
        _boostParticle.transform.position = position;
        _boostParticle.Play();
    }
    
    public void PlayBreakableParticleSystemAt(Vector2 position)
    {
        _breakableParticle.transform.position = position;
        _breakableParticle.Play();
    }
    
    public void StopBoostParticleSystem()
    {
        _boostParticle.Stop();
    }

    public void PlayDarkScreenAnimation()
    {
        _darkScreenAnimator.enabled = true;
        _darkScreenAnimator.SetBool(DARKFADE_ANIM_NAME, true);
    }

    public void PlayPlayerJumpAnimation()
    {
        _playerAnimator.Play(JUMP_ANIM_NAME, -1, 0);
        _playerAnimator.Play(JUMP_ANIM_NAME);
    }
}
