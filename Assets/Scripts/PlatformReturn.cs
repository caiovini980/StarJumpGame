using System;
using UnityEngine;

public class PlatformReturn : MonoBehaviour
{
    private ObjectPooler _objectPooler;

    private void Start()
    {
        _objectPooler = FindObjectOfType<ObjectPooler>();
    }

    private void OnDisable()
    {
        if (_objectPooler != null)
        {
            Debug.Log("Returning a platform");
            _objectPooler.ReturnGameObject(gameObject);
        }
    }
}
