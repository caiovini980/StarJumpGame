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
        Jump(characterInPlatform);
        _shakeTransform.AddShakeEvent(_shakeData);
        _sound.Play();
    }

    private void Jump(Rigidbody2D rigidbody)
    {
        _velocity = rigidbody.velocity;
        _velocity.y = _platform.jumpSpeed;
        _velocity.x -= _velocity.x / 3;
        rigidbody.velocity = _velocity;
    }
}
