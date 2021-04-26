using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    /*[SerializeField] private GameObject _platformPrefab;
    [SerializeField] private Queue<GameObject> _platformPool = new Queue<GameObject>();
    [SerializeField] private int _poolSize = 20;
    public int PoolSize
    {
        get => _poolSize;
        set => _poolSize = value;
    }

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject platform = Instantiate(_platformPrefab);
            _platformPool.Enqueue(platform);
            platform.SetActive(false);
        }
    }

    public GameObject GetPlatform()
    {
        if (_platformPool.Count > 0)
        {
            GameObject platform = _platformPool.Dequeue();
            platform.SetActive(true);
            return platform;
        }

        return null;
    }

    public void ReturnPlatform(GameObject platform)
    {
        _platformPool.Enqueue(platform);
        platform.SetActive(false);
    }*/

    private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();

    public GameObject GetObject(GameObject gameObject)
    {
        //PlatformType platform = gameObject.GetComponent<PlatformBase>().GetType();
        
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objects))
        {
            if (objects.Count == 0)
            {
                return CreateNewObject(gameObject);
            }
            else
            {
                GameObject _object = objects.Dequeue();
                _object.SetActive(true);
                return _object;
            }
        }
        else
        {
            return CreateNewObject(gameObject);
        }
    }

    private GameObject CreateNewObject(GameObject gameObject)
    {
        GameObject _newGameObject = Instantiate(gameObject);
        
        //PlatformType gameObjectType = gameObject.GetComponent<PlatformBase>().GetType();
        //PlatformType newPlatformType = _newGameObject.GetComponent<PlatformBase>().GetType();
        //newPlatformType = gameObjectType;
        
        _newGameObject.name = gameObject.name;
        
        return _newGameObject;
    }

    public void ReturnGameObject(GameObject gameObject)
    {
        //PlatformType platform = gameObject.GetComponent<PlatformBase>().GetType();
        
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objects))
        {
            objects.Enqueue(gameObject);
        }
        else
        {
            Queue<GameObject> _newObjectQueue = new Queue<GameObject>();
            _newObjectQueue.Enqueue(gameObject);
            objectPool.Add(gameObject.name, _newObjectQueue);
        }
        
        gameObject.SetActive(false);
    }
}
