using System;
using System.Collections;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    protected abstract void PlatformEffect(Rigidbody2D characterInPlatform);

    private float _collisionVelocity;

    [SerializeField] private GameObject _deathZone;
    [SerializeField] private PlatformType _type { get; set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collisionVelocity = collision.rigidbody.velocity.y;
        
        if (_collisionVelocity <= 0f)
        {
            Rigidbody2D playerRigidbody = collision.collider.GetComponent<Rigidbody2D>();
                    
            if (playerRigidbody != null)
            {
                PlatformEffect(playerRigidbody);
            }
        }
    }

    public PlatformType GetType()
    {
        return _type;
    }
}
