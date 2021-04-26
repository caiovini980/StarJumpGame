using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageSettings
{
    [Space(1)] 
    public string name;
    public float startPoint;
    public float endPoint;
    [Range(0, 100)] public int seedWeight;
    
    public List<PlatformsSpawnSettings> availablePlatforms = new List<PlatformsSpawnSettings>();
}
