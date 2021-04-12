using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Camera _camera;
    
    [SerializeField] private Transform background1;
    [SerializeField] private Transform background2;

    private float _size;
    
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _size = background1.GetComponent<BoxCollider2D>().size.y;
    }

    private void FixedUpdate()
    {
        if (_camera.transform.position.y >= background2.position.y)
        {
            background1.position = new Vector3(background1.position.x, background2.position.y + _size, background1.position.z);
            SwitchBackground();
        }
    }

    private void SwitchBackground()
    {
        Transform temporaryBackground = background1;
        background1 = background2;
        background2 = temporaryBackground;
    }
}
