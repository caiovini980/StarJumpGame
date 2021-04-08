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
    [SerializeField] private GameObject _normalPrefab;
    [SerializeField] private GameObject _breakablePrefab;
    [SerializeField] private GameObject _boostPrefab;
    [SerializeField] private GameObject _deathPrefab;
    [SerializeField] private UIManager _uiManager;
    
    private Vector2 _spawnPlatformPosition;
    private Vector2 _screenBoundsX;

    private int _distanceToSpawn = 5;

    private float _timeToSpawnAgain = 10f;
    private float _timeSinceSpawn;

    public bool _canSpawnSpecialPlatform = true;
    public bool _hasSpawnedDeathPlatform = false;

    private void Start()
    {
        _screenBoundsX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Camera.main.transform.position.y));
        _spawnPlatformPosition = new Vector2(firstPlatform.transform.position.x, firstPlatform.transform.position.y + 0.5f);
    }

    private void Update()
    {
        float distanceToThePlatform = Vector2.Distance(player.transform.position, _spawnPlatformPosition);

        if (_hasSpawnedDeathPlatform)
        {
            if (distanceToThePlatform < _distanceToSpawn)
            {
                SpawnPlatforms();
                _hasSpawnedDeathPlatform = false;
            }
        }

        else
        {
            if (distanceToThePlatform < _distanceToSpawn + 2)
            {
                SpawnPlatforms();
            }
        }

        if (!_canSpawnSpecialPlatform)
        {
            _timeSinceSpawn += Time.deltaTime;
            if (_timeSinceSpawn >= _timeToSpawnAgain)
            {
                _canSpawnSpecialPlatform = true;
            }
        }
    }

    private void SpawnPlatforms()
    {
        _spawnPlatformPosition = new Vector2(GetRandomPositionX(), _spawnPlatformPosition.y + 1f);
        
        //Aparece muitas plataformas normais
        if (_uiManager.GetScore() <= 500)
        {
            _pooler.GetObject(_normalPrefab).transform.position = _spawnPlatformPosition;
        }

        //Aparece menos plataformas normais e aparecem plataformas que quebram
        if (_uiManager.GetScore() > 500 && _uiManager.GetScore() <= 1500)
        {
            if (GetRandomValueFromZeroToHundred() <= 50)
            {
                _pooler.GetObject(_normalPrefab).transform.position = _spawnPlatformPosition;
            }
            else
            {
                _pooler.GetObject(_breakablePrefab).transform.position = _spawnPlatformPosition;
            }
        }
        
        //Aparece plataformas de boost em uma frequencia bem menor
        if (_uiManager.GetScore() > 1500 && _uiManager.GetScore() <= 4000)
        {
            float randomValue = GetRandomValueFromZeroToHundred();
            
            if (randomValue <= 40)
            {
                _pooler.GetObject(_normalPrefab).transform.position = _spawnPlatformPosition;
            }
            
            else if (randomValue > 40 && randomValue <= 80 )
            {
                _pooler.GetObject(_breakablePrefab).transform.position = _spawnPlatformPosition;
            }
            
            else if (randomValue > 80 && _canSpawnSpecialPlatform)
            {
                _pooler.GetObject(_boostPrefab).transform.position = _spawnPlatformPosition;
                _canSpawnSpecialPlatform = false;
            }

            else
            {
                _pooler.GetObject(_breakablePrefab).transform.position = _spawnPlatformPosition;
            }
        }
        
        //Aparecem tambem as plataformas que matam o player, sempre acompanhadas de uma plataforma normal
        if (_uiManager.GetScore() > 4000)
        {
            float randomValue = GetRandomValueFromZeroToHundred();
            
            if (randomValue <= 40)
            {
                _pooler.GetObject(_normalPrefab).transform.position = _spawnPlatformPosition;
            }
            
            else if (randomValue > 40 && randomValue <= 80 )
            {
                _pooler.GetObject(_breakablePrefab).transform.position = _spawnPlatformPosition;
            }
            
            else if (randomValue > 80 && _canSpawnSpecialPlatform)
            {
                float randomSpecialPlatform = Random.Range(0, 9);
                
                if (randomSpecialPlatform <= 4)
                {
                    _pooler.GetObject(_boostPrefab).transform.position = _spawnPlatformPosition;
                    _canSpawnSpecialPlatform = false;
                }
                else
                {
                    _pooler.GetObject(_deathPrefab).transform.position = _spawnPlatformPosition;
                    _hasSpawnedDeathPlatform = true;
                    _canSpawnSpecialPlatform = false;
                }
            }

            else
            {
                float randomNormalPlatform = Random.Range(0, 2);
                
                if (randomNormalPlatform == 0)
                {
                    _pooler.GetObject(_normalPrefab).transform.position = _spawnPlatformPosition;
                }
                else
                {
                    _pooler.GetObject(_breakablePrefab).transform.position = _spawnPlatformPosition;
                }
            }
        }
    }

    private float GetRandomValueFromZeroToHundred()
    {
        return Random.Range(0, 101);
    }

    private float GetRandomPositionX()
    {
        return Random.Range(_screenBoundsX.x, -_screenBoundsX.x);
    }
}
