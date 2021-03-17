using UnityEngine;

[CreateAssetMenu(fileName = "New Platform", menuName = "Platform")]
public class Platform : ScriptableObject
{
    public float jumpSpeed = 8f;
    
    public bool isDeadly;
    public bool isBreakable;
}
