using UnityEngine;

[CreateAssetMenu(fileName = "New Platform", menuName = "Platforms/New Platform", order = 1)]
public class Platform : ScriptableObject
{
    public float jumpSpeed = 8f;
    
    public bool isDeadly;
    public bool isBreakable;
}
