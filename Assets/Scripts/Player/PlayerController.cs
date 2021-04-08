using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _deathPoint;
    
    private UIManager _uiManager;

    private AnimationManager _animationManager;
    
    private Camera _camera;
    
    private Transform _playerTransform;
    
    private Rigidbody2D _rigidbody;

    private PlayerInputListener _playerInput;
    
    private Vector3 _newPosition;

    private Vector2 _newScreenBounds;
    private Vector2 _screenBounds;

    private float _screenWidth;
    private float _topScore = 0f;
    private const float SPEED = 10f;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputListener>();
        _playerTransform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        
        _animationManager = GameObject.Find("AnimationManager").GetComponent<AnimationManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        _playerInput.OnMove += CalculateHorizontalMovement;
        _playerInput.OnStop += CalculateHorizontalMovement; 
        
        _camera = Camera.main;
        _screenWidth = Screen.width;
    }

    private void Start()
    {
        _screenBounds = new Vector3(_screenWidth, _camera.transform.position.y);
        _newScreenBounds = _camera.ScreenToWorldPoint(_screenBounds);
    }

    private void OnDisable()
    {
        _playerInput.OnMove -= CalculateHorizontalMovement;
        _playerInput.OnStop -= CalculateHorizontalMovement;
    }

    private void FixedUpdate()
    {
        if (_playerInput.CheckMovementStatus())
        {
            if (_newPosition.x > 0)
            {
                _rigidbody.AddForce(Vector2.right * SPEED, ForceMode2D.Force);
            }
            
            else if (_newPosition.x < 0)
            {
                _rigidbody.AddForce(Vector2.left * SPEED, ForceMode2D.Force);
            }
        }
    }

    private void Update()
    {
        KeepPlayerOnScreen();

        if (transform.position.y > _topScore)
        {
            _topScore = transform.position.y;
            _uiManager.UpdateScore(_topScore);
        }
        
        if (transform.position.y < _deathPoint.transform.position.y - 5f)
        {
            gameObject.SetActive(false);
        }
    }

    private void CalculateHorizontalMovement(Vector2 position)
    {
        _newPosition = _camera.ScreenToWorldPoint(position);
    }
    
    private void KeepPlayerOnScreen()
    {
        if (_playerTransform.position.x > _newScreenBounds.x)
        {
            _playerTransform.position = new Vector2(-_newScreenBounds.x, transform.position.y);
        }
        
        else if (_playerTransform.position.x < -_newScreenBounds.x)
        {
            _playerTransform.position = new Vector2(_newScreenBounds.x, transform.position.y);
        }
    }
}
