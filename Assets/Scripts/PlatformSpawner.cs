using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject player;
    
    public bool _canSpawnSpecialPlatform = true;
    public bool _canSpawnDeathPlatform = false;

    [SerializeField] private UIManager _uiManager;
    [SerializeField] private ObjectPooler _pooler;
    
    private GameObject _normalPrefab;
    private GameObject _breakablePrefab;
    private GameObject _boostPrefab;
    private GameObject _deathPrefab;
    
    private int _distanceToSpawn = 5;
    private float _timeToSpawnAgain = 10f;
    private float _timeSinceSpawn;
    
    public GameObject firstPlatform;
    public List<GameStages> stages = new List<GameStages>();

    private Vector2 _spawnPlatformPosition;
    private Vector2 _screenBoundsX;
    
    private List<StageSettings> stageSettings = new List<StageSettings>();
    private List<PlatformsSpawnSettings> availablePlatforms = new List<PlatformsSpawnSettings>();
    private List<GameObject> platformsToSpawn = new List<GameObject>();

    private void Start()
    {
        _screenBoundsX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Camera.main.transform.position.y));
        _spawnPlatformPosition = new Vector2(firstPlatform.transform.position.x, firstPlatform.transform.position.y + 0.5f);

        foreach (GameStages stage in stages)
        {
            stageSettings = stage.stageSettings;

            foreach (StageSettings settings in stageSettings)
            {
                availablePlatforms = settings.availablePlatforms;
            }
        }
        
        _normalPrefab = stages[0].stageSettings[0].availablePlatforms[0].plataformPrefab;
        _breakablePrefab = stages[1].stageSettings[0].availablePlatforms[1].plataformPrefab;
        _boostPrefab = stages[2].stageSettings[0].availablePlatforms[2].plataformPrefab;
        _deathPrefab = stages[3].stageSettings[0].availablePlatforms[3].plataformPrefab;
        
        Debug.Log(_breakablePrefab.name);
    }

    private void Update()
    {
        float distanceToThePlatform = Vector2.Distance(player.transform.position, _spawnPlatformPosition);

        if (_canSpawnDeathPlatform)
        {
            if (distanceToThePlatform < _distanceToSpawn - 2)
            {
                SpawnPlatforms();
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
                _canSpawnDeathPlatform = true;
                _timeSinceSpawn = 0f;
            }
        }
    }

    private void SpawnPlatforms()
    {
        _spawnPlatformPosition = new Vector2(GetRandomPositionX(), _spawnPlatformPosition.y + 1f);

        //********** MAGIC NUMBERS **********
        //Aparece muitas plataformas normais
        if (_uiManager.GetScore() <= stages[0].stageSettings[0].endPoint)
        {
            _pooler.GetObject(_normalPrefab).transform.position = _spawnPlatformPosition;
        }

        //Aparece menos plataformas normais e aparecem plataformas que quebram
        if (_uiManager.GetScore() > stages[1].stageSettings[0].startPoint &&
            _uiManager.GetScore() <= stages[1].stageSettings[0].endPoint)
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
        if (_uiManager.GetScore() > stages[2].stageSettings[0].startPoint &&
            _uiManager.GetScore() <= stages[2].stageSettings[0].endPoint)
        {
            float randomValue = GetRandomValueFromZeroToHundred();

            if (randomValue <= 40)
            {
                _pooler.GetObject(_normalPrefab).transform.position = _spawnPlatformPosition;
            }

            else if (randomValue > 40 && randomValue <= 80)
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
        if (_uiManager.GetScore() > stages[3].stageSettings[0].startPoint &&
            _uiManager.GetScore() >= stages[3].stageSettings[0].endPoint)
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
                    _canSpawnDeathPlatform = false;
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
