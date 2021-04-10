using System;
using System.Collections;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    protected abstract void Initialize();
    protected abstract void PlatformEffect(Rigidbody2D characterInPlatform);

    private float _collisionVelocity;
    
    private PlayerController _player;

    protected AudioSource _sound;
    
    private AnimationManager _animationManager;

    [SerializeField] private PlatformType _type;

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _player = GameManager.sInstance.Player;
        _animationManager = GameManager.sInstance.AnimationManager;
            
        Initialize();
    }

    private void Update()
    {
        if (transform.position.y < _player.transform.position.y - 5f)
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
                PlatformEffect(playerRigidbody);
                _animationManager.PlayPlayerJumpAnimation();
                _animationManager.PlayPlayerParticleSystemAt(collision.transform.position);
            }
        }
    }

    public PlatformType GetType()
    {
        return _type;
    }
}
