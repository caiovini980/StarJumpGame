using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPooler _pooler;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private PlayerController _player;
    [SerializeField] private UIManager _uiManager;
    
    [SerializeField] private int _poolSize = 20;
    [SerializeField] private float minY = .2f;
    [SerializeField] private float maxY = 1.5f;
    
    private float _screenLimit = 2f;

    private List<GameObject> normalPlatforms = new List<GameObject>();

    private void Start()
    {
        Vector3 spawnPosition = new Vector3();
        
        for (int i = 0; i < _poolSize; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-_screenLimit, _screenLimit);
            
            GameObject platform = _pooler.GetObject(_prefab);
            platform.transform.position = new Vector2(spawnPosition.x, spawnPosition.y);
            
            normalPlatforms.Add(platform);
        }
    }

    private void Update()
    {
        Debug.Log(normalPlatforms.Count);
        
        if (_uiManager.GetScore() < 200)
        {
            //Aparece muitas plataformas normais
        }

        if (_uiManager.GetScore() > 200 && _uiManager.GetScore() <= 650)
        {
            //Aparece menos plataformas e aparecem tambem plataformas que quebram
        }

        if (_uiManager.GetScore() > 650 && _uiManager.GetScore() <= 900)
        {
            //Aparece plataformas de boost em uma frequencia bem menor
        }

        if (_uiManager.GetScore() > 900)
        {
            //Aparecem tambem as plataformas que matam o player, sempre acompanhadas de uma plataforma normal
        }
    }
}
