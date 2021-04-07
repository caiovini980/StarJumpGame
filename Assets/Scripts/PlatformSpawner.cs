using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject firstPlatform;
    
    [SerializeField] private ObjectPooler _pooler;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolSize = 10;
    [SerializeField] private UIManager _uiManager;

    private Vector2 _spawnPlatformPosition;
    private Vector2 _screenBoundsX;

    private int _distanceToSpawn = 5;

    private void Start()
    {
        _screenBoundsX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Camera.main.transform.position.y));
        _spawnPlatformPosition = new Vector2(firstPlatform.transform.position.x, firstPlatform.transform.position.y + 0.5f);
        
        /*for (int i = 0; i < _poolSize; i++)
        {
            GameObject platform = _pooler.GetObject(_prefab);
            platform.SetActive(false);
            platform.transform.position = _spawnPlatformPosition;
        }*/
    }

    private void Update()
    {
        float distanceToThePlatform = Vector2.Distance(player.transform.position, _spawnPlatformPosition);

        if (distanceToThePlatform < _distanceToSpawn + 2)
        {
            SpawnPlatforms();
        }
    }

    private void SpawnPlatforms()
    {
        _spawnPlatformPosition = new Vector2(GetRandomPositionX(), _spawnPlatformPosition.y + 1f);
        
        if (_uiManager.GetScore() < 10000)
        {
            _pooler.GetObject(_prefab).transform.position = _spawnPlatformPosition;
        }
    }

    private float GetRandomPositionX()
    {
        return Random.Range(_screenBoundsX.x, -_screenBoundsX.x);
    }

    /*[SerializeField] private ObjectPooler _pooler;
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
        Vector3 spawnPosition = new Vector3(0, -1.3f, 0);
        
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
    }*/
}
