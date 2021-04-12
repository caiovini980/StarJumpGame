using System.Collections;
using UnityEngine;

public class BreakablePlatform : PlatformBase
{
    [SerializeField] private Platform _platform = default;

    private Vector3 _velocity;
    
    protected override void Initialize()
    {
    }
    
    protected override void PlatformEffect(Rigidbody2D characterInPlatform)
    {
        Jump(characterInPlatform);
        _sound.Play();
        StartCoroutine(WaitToDeactivate(0.3f));
    }
    
    private void Jump(Rigidbody2D rigidbody)
    {
        _velocity = rigidbody.velocity;
        _velocity.y = _platform.jumpSpeed;
        _velocity.x -= _velocity.x / 3;
        rigidbody.velocity = _velocity;
    }

    IEnumerator WaitToDeactivate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _animationManager.PlayBreakableParticleSystemAt(transform.position);
        gameObject.SetActive(false);
    }
}
