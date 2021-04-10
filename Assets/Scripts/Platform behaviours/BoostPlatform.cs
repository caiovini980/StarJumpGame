using System;
using UnityEngine;

public class BoostPlatform : PlatformBase
{
    [SerializeField] private Platform _platform = default;
    [SerializeField] private ShakeTransformEventData _shakeData;
    
    private ShakeTransform _shakeTransform;

    private Vector3 _velocity;

    protected override void Initialize()
    {
        _shakeTransform = Camera.main.GetComponentInParent<ShakeTransform>();
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
