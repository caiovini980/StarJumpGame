using UnityEngine;

public class DeathPlatform : PlatformBase
{
    protected override void PlatformEffect(Rigidbody2D characterInPlatform)
    {
        Debug.Log("MORRE FDP");
        
        characterInPlatform.gameObject.SetActive(false);
    }
}
