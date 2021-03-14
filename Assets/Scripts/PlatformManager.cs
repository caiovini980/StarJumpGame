using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab;

    private int _numberOfPlatforms = 100;
    private float _levelWidth = 3f;
    private float _minY = .2f;
    private float _maxY = 1f;
    
    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        
        for (int i = 0; i < _numberOfPlatforms; i++)
        {
            spawnPosition.x = Random.Range(-_levelWidth, _levelWidth);
            spawnPosition.y += Random.Range(_minY, _maxY);
            Instantiate(_platformPrefab, spawnPosition, quaternion.identity);
        }
    }
}
