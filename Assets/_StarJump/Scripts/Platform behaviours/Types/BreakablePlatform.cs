using System.Collections;
using UnityEngine;

public class BreakablePlatform : PlatformBase
{
    [SerializeField] private Platform _platform = default;

    private ParticleSystem _breakableParticle;

    [SerializeField] private float _timeToPlayEffects = 0.3f;
    
    private Vector3 _velocity;

    protected override void Initialize()
    {
        _breakableParticle = GetComponentInChildren<ParticleSystem>();
    }
    
    protected override void PlatformEffect(Rigidbody2D characterInPlatform)
    {
        Jump(characterInPlatform);
        _breakableParticle.Play();
        _sound.Play();
        
        StartCoroutine(WaitToDeactivate(_timeToPlayEffects));
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
        gameObject.SetActive(false);
    }
}
