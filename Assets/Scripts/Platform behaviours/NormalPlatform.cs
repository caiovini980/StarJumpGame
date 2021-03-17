using UnityEngine;

public class NormalPlatform : Platforms, IJumpable
{
    public Platform platform;
    
    private Vector2 _velocity;
    
    private float _collisionVelocity; // > 0 = going up; < 0 = going down

    private bool _hasJumped;

    public void Jump(Rigidbody2D rigidbody, float jumpForce)
    {
        _velocity = rigidbody.velocity;
        _velocity.y = jumpForce;
        _velocity.x -= _velocity.x / 3;
        rigidbody.velocity = _velocity;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collisionVelocity = collision.rigidbody.velocity.y;
        
        if (_collisionVelocity <= 0f)
        {
            Rigidbody2D playerRigidbody = collision.collider.GetComponent<Rigidbody2D>();
                    
            if (playerRigidbody != null)
            {
                IJumpable jumpable = GetComponent<IJumpable>();
                jumpable.Jump(playerRigidbody, platform.jumpSpeed);
                PlatformEffect();
            }
        }
    }

    protected override void PlatformEffect()
    {
        
    }
}
