using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour, IJumpable
{
    private Vector2 _velocity;
    
    private const float JUMP_FORCE = 8f;
    private float _collisionVelocity; // > 0 = going up; < 0 = going down
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collisionVelocity = collision.relativeVelocity.y;
        
        if (_collisionVelocity <= 0f)
        {
            Rigidbody2D playerRigidbody = collision.collider.GetComponent<Rigidbody2D>();
                    
            if (playerRigidbody != null)
            {
                IJumpable jumpable = GetComponent<IJumpable>();
                jumpable.Jump(playerRigidbody, JUMP_FORCE);
            }
        }
    }

    public void Jump(Rigidbody2D rigidbody, float jumpForce)
    {
        _velocity = rigidbody.velocity;
        _velocity.y = jumpForce;
        rigidbody.velocity = _velocity;
    }
}
