using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlatformsSpawnSettings
{
    [Space(1)] 
    public string name;
    public GameObject plataformPrefab;
    [Range(0, 100)] public int spawnChance;
    [Range(0, 100)] public int spawnChangeSeedWeight;
}
