using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomSeed : MonoBehaviour
{
    public string stringSeed = "seed string";

    public bool generateRandomSeed;

    public int seed;
    
    // Start is called before the first frame update
    void Awake()
    {
        seed = stringSeed.GetHashCode();

        if (generateRandomSeed)
        {
            seed = Random.Range(-99999, 99999);
        }
        
        Random.InitState(seed);
    }
}
