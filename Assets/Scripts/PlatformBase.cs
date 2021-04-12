using System;
using System.Collections;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    public int streak = 0;
    
    protected abstract void Initialize();
    protected abstract void PlatformEffect(Rigidbody2D characterInPlatform);

    private float _collisionVelocity;
    private float _timeToNormalizeGame = 1f;
    private float _timeSinceGamePaused = 0f;
    
    private PlayerController _player;
    
    protected AnimationManager _animationManager;

    protected UIManager _uiManager;

    protected AudioSource _sound;
    
    [SerializeField] protected PlatformType _type;

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _player = GameManager.sInstance.Player;
        _animationManager = GameManager.sInstance.AnimationManager;
        _uiManager = GameManager.sInstance.UIManager;
        
        Initialize();
    }

    private void Update()
    {
        if (transform.position.y < _player.transform.position.y - 5f)
        {
            gameObject.SetActive(false);
        }

        if (Time.timeScale == 0)
        {
            _timeSinceGamePaused += Time.unscaledDeltaTime;
            
            if (_timeSinceGamePaused >= _timeToNormalizeGame)
            {
                _timeSinceGamePaused = 0f;
                _uiManager.MakeScreenNormal();
                _animationManager.StopBoostParticleSystem();
                Time.timeScale = 1f;
            }
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
                PlatformEffect(playerRigidbody);
                _animationManager.PlayPlayerJumpAnimation();
                _animationManager.PlayPlayerParticleSystemAt(playerRigidbody.transform.position);
            }
        }
    }

    public PlatformType GetType()
    {
        return _type;
    }
}
