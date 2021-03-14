using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHorizontalMovement : MonoBehaviour
{
    private Camera _camera;
    
    private Transform _playerTransform;
    
    private Rigidbody2D _rigidbody;
    
    private PlayerMovementInputs _playerInput;
    
    private Vector3 _touchPosition;
    private Vector3 _newPosition;

    private Vector2 _newScreenBounds;
    private Vector2 _screenBounds;

    private float _screenWidth;
    private float _touchPress;
    private const float SPEED = 10f;
    
    private void Awake()
    {
        _playerInput = new PlayerMovementInputs();
        _playerTransform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _screenWidth = Screen.width;
    }

    private void Start()
    {
        _screenBounds = new Vector3(_screenWidth, _camera.transform.position.y);
        _newScreenBounds = _camera.ScreenToWorldPoint(_screenBounds);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        CalculateHorizontalMovement();
    }

    private void Update()
    {
        KeepPlayerOnScreen();
    }

    private void CalculateHorizontalMovement()
    {
        //Pegar o input no update e trabalhar ele no fixedupdate
        _touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        _newPosition = _camera.ScreenToWorldPoint(_touchPosition);

        _touchPress = Touchscreen.current.primaryTouch.press.ReadValue();
        
        if (_touchPress > 0.1)
        {
            if (_newPosition.x > 0)
            {
                _rigidbody.AddForce(Vector2.right * SPEED, ForceMode2D.Force);
                /*_currentPosition = transform.position;
                _currentPosition.x += SPEED * Time.deltaTime;
                transform.position = _currentPosition;*/
            }
            
            else if (_newPosition.x < 0)
            {
                _rigidbody.AddForce(Vector2.left * SPEED, ForceMode2D.Force);
                /*_currentPosition = transform.position;
                _currentPosition.x += -SPEED * Time.deltaTime;
                transform.position = _currentPosition;*/
            }
        }
    }
    
    private void KeepPlayerOnScreen()
    {
        if (_playerTransform.position.x > _newScreenBounds.x)
        {
            _playerTransform.position = new Vector2(_newScreenBounds.x, transform.position.y);
        }
        
        else if (_playerTransform.position.x < -_newScreenBounds.x)
        {
            _playerTransform.position = new Vector2(-_newScreenBounds.x, transform.position.y);
        }
    }
}
