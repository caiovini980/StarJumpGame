using UnityEngine;

public class Platform : MonoBehaviour, IJumpable
{
    private Vector2 _velocity;
    
    [SerializeField] private float _jumpForce = 8f;
    private float _collisionVelocity; // > 0 = going up; < 0 = going down

    public void Jump(Rigidbody2D rigidbody, float jumpForce)
    {
        _velocity = rigidbody.velocity;
        _velocity.y = jumpForce;
        _velocity.x -= _velocity.x / 3;
        rigidbody.velocity = _velocity;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collisionVelocity = collision.relativeVelocity.y;
        
        if (_collisionVelocity <= 0f)
        {
            Rigidbody2D playerRigidbody = collision.collider.GetComponent<Rigidbody2D>();
                    
            if (playerRigidbody != null)
            {
                IJumpable jumpable = GetComponent<IJumpable>();
                jumpable.Jump(playerRigidbody, _jumpForce);
            }
        }
    }
}
