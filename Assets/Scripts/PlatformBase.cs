using System;
using System.Collections;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    protected abstract void PlatformEffect(Rigidbody2D characterInPlatform);

    private float _collisionVelocity;
    
    private GameObject _player;
    
    private AnimationManager _animationManager;

    private const string PLAYER_NAME = "Player";
    private const string ANIM_MANAGER_NAME = "AnimationManager";
    
    [SerializeField] private PlatformType _type { get; set; }

    private void Awake()
    {
        _player = GameObject.Find(PLAYER_NAME);
        _animationManager = GameObject.Find(ANIM_MANAGER_NAME).GetComponent<AnimationManager>();
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
            }
        }
    }

    public PlatformType GetType()
    {
        return _type;
    }
}
