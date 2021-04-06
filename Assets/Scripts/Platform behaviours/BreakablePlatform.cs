using UnityEngine;

public class BreakablePlatform : PlatformBase
{
    [SerializeField] private Platform _platform = default;

    private Vector3 _velocity;
    
    private void Jump(Rigidbody2D rigidbody)
    {
        _velocity = rigidbody.velocity;
        _velocity.y = _platform.jumpSpeed;
        _velocity.x -= _velocity.x / 3;
        rigidbody.velocity = _velocity;
    }
    
    protected override void PlatformEffect(Rigidbody2D characterInPlatform)
    {
        Jump(characterInPlatform);
        gameObject.SetActive(false);
    }
}
