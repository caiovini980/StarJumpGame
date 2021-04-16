using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _parallaxSpeed;
    
    private Camera _camera;
    private float _length;
    private float _startPosition;

    private void Awake()
    {
        _length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _startPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (_camera.transform.position.y * (1 - _parallaxSpeed));
        float distance = (_camera.transform.position.y * _parallaxSpeed);

        transform.position = new Vector3(transform.position.x, _startPosition + distance, transform.position.z);

        if (temp > _startPosition + _length)
        {
            _startPosition += _length;
        }
        
        else if (temp < _startPosition - _length)
        {
            _startPosition -= _length;
        }
    }
}
