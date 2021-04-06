using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformType
{
    NORMAL,
    BOOST,
    BREAKABLE,
    DEATH
}

public class PlatformTypes : MonoBehaviour
{
    private PlatformType _type;
}
