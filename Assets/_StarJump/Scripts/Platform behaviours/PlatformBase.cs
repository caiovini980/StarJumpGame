using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    [SerializeField] private float _offsetToDie = 6f;

    protected abstract void Initialize();
    
    protected abstract void PlatformEffect(Rigidbody2D characterInPlatform);

    protected AudioSource _sound;
    
    private float _collisionVelocity;

    protected bool _canCombo;
    
    private PlayerController _player;

    private UIManager _uiManager;

    //[SerializeField] protected PlatformType _type;

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _canCombo = true;
    }

    private void Start()
    {
        _player = GameManager.sInstance.Player;
        _uiManager = GameManager.sInstance.UIManager;
        
        Initialize();
    }

    private void Update()
    {
        if (transform.position.y < _player.transform.position.y - _offsetToDie)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collisionVelocity = collision.rigidbody.velocity.y;
        
        if (_collisionVelocity <= 0f)
        {
            Rigidbody2D playerRigidbody = collision.collider.GetComponent<Rigidbody2D>();
                  
            if (playerRigidbody != null)
            {
                if (_canCombo)
                {
                    _uiManager.ShowComboMultiplier(1);
                    _canCombo = false;
                }
                else
                {
                    _uiManager.ResetCombo();
                }
                
                PlatformEffect(playerRigidbody);
                _player.PlayJumpAnimation();
                _player.PlayParticleSystemAt(playerRigidbody.transform.position);
            }
        }
    }
    
    /*public PlatformType GetType()
    {
        return _type;
    }*/
}
