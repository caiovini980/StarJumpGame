using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector2 _startPosition;
    private float _repeatHeight;
    private PlayerController _player;

    private void Awake()
    {
        _repeatHeight = GetComponent<BoxCollider2D>().size.y / 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        _player = GameManager.sInstance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.transform.position.y < _startPosition.y + _repeatHeight)
        {
            Debug.Log("SURPRESA");
        }
    }
}
