using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage", menuName = "Platforms/New Stage", order = 2)]
public class GameStages : ScriptableObject
{
    public List<StageSettings> stageSettings = new List<StageSettings>();
}
