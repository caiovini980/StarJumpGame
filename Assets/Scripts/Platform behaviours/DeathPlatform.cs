using UnityEngine;

public class DeathPlatform : PlatformBase
{
    protected override void Initialize()
    {
    }
    
    protected override void PlatformEffect(Rigidbody2D characterInPlatform)
    {
        Debug.Log("MORRE FDP");
        
        _sound.Play();
        characterInPlatform.gameObject.SetActive(false);
    }
}
