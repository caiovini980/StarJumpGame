using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public new Camera camera;

    private Transform _playerTransform;
    
    private Rigidbody2D _rigidbody;

    private Vector2 _screenBounds;
    private Vector2 _newScreenBounds;

    private float _screenWidth;
    private const float SPEED = 10f;
    private bool _isTouched;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerTransform = GetComponent<Transform>();
        _screenWidth = Screen.width;
        //camera = Camera.main;
    }

    private void Start()
    {
        _newScreenBounds = new Vector3(_screenWidth, camera.transform.position.y);
        _screenBounds = camera.ScreenToWorldPoint(_newScreenBounds);
    }

    private void Update()
    {
        KeepPlayerOnScreen();
        
        CalculateMovement();
    }

    private void KeepPlayerOnScreen()
    {
        if (_playerTransform.position.x > _screenBounds.x)
        {
            _playerTransform.position = new Vector2(_screenBounds.x, transform.position.y);
        }
        
        else if (_playerTransform.position.x < -_screenBounds.x)
        {
            _playerTransform.position = new Vector2(-_screenBounds.x, transform.position.y);
        }
    }

    private void CalculateMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began: 
                    _isTouched = true;
                    break;
                
                case TouchPhase.Stationary:
                    if (_isTouched && touch.position.x > _screenWidth / 2)
                    {
                        MoveRight();
                    }
                    
                    else if (_isTouched && touch.position.x < _screenWidth / 2)
                    {
                        MoveLeft();
                    }
                    break;
                
                case TouchPhase.Ended:
                    StopMovement();
                    break;
            }
        }
    }

    private void MoveRight()
    {
        _rigidbody.velocity = new Vector2(SPEED, _rigidbody.velocity.y);
    }

    private void MoveLeft()
    {
        _rigidbody.velocity = new Vector2(-SPEED, _rigidbody.velocity.y);
    }

    private void StopMovement()
    {
        _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);
    }
}
