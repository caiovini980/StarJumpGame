using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoostPlatform : PlatformBase
{
    [SerializeField] private Platform _platform = default;
    [SerializeField] private ShakeTransformEventData _shakeData;
    
    private ShakeTransform _shakeTransform;

    private Camera _camera;

    private Vector3 _velocity;

    protected override void Initialize()
    {
        _camera = Camera.main;
        _shakeTransform = _camera.GetComponentInParent<ShakeTransform>();
    }

    protected override void PlatformEffect(Rigidbody2D characterInPlatform)
    {
        if (_type == PlatformType.BOOST)
        {
            Time.timeScale = 0f;
            
            _animationManager.PlayBoostParticleSystemAt(characterInPlatform.transform.position);
            _animationManager.PlayPlayerParticleSystemAt(characterInPlatform.transform.position);
            
            _uiManager.MakeDarkerScreen();
            
            Jump(characterInPlatform);
            
            _shakeTransform.AddShakeEvent(_shakeData);
            _sound.Play();
        }
        else
        {
            Jump(characterInPlatform);
            _sound.Play();
        }
    }

    private void Jump(Rigidbody2D rigidbody)
    {
        _velocity = rigidbody.velocity;
        _velocity.y = _platform.jumpSpeed;
        _velocity.x -= _velocity.x / 3;
        rigidbody.velocity = _velocity;
    }
}
