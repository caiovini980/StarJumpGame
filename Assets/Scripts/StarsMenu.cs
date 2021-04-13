using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsMenu : MonoBehaviour
{
    private Camera _camera;
    
    [SerializeField] private Transform _stars1;
    [SerializeField] private Transform _stars2;

    private float _size;
    private float _speed = 3f;
    
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _size = _stars1.GetComponent<BoxCollider2D>().size.y;
    }

    private void FixedUpdate()
    {
        _stars1.transform.Translate(Vector3.down * Time.deltaTime * _speed);
        _stars2.transform.Translate(Vector3.down * Time.deltaTime * _speed);
        
        if (_camera.transform.position.y >= _stars2.position.y)
        {
            _stars1.position = new Vector3(_stars1.position.x, _stars2.position.y + _size, _stars1.position.z);
            SwitchBackground();
        }
    }

    private void SwitchBackground()
    {
        Transform temporaryBackground = _stars1;
        _stars1 = _stars2;
        _stars2 = temporaryBackground;
    }
}