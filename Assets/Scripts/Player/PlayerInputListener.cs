using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputListener : MonoBehaviour
{
    [SerializeField] private PlayerMovementInputs _controls;
    [SerializeField] private Vector2 _inputPosition;

    public delegate void OnPlayerMove(Vector2 position);
    public OnPlayerMove OnMove;

    public delegate void OnPlayerStop(Vector2 position);
    public OnPlayerStop OnStop;

    private bool _isMoving = default;
    
    private void Awake()
    {
        InitializeInputs();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
        _controls.PlayerMain.MoveStart.performed -= MoveStartInput;
        _controls.PlayerMain.MoveEnd.performed -= MoveEndInput;
    }

    public void MoveStartInput(InputAction.CallbackContext context)
    {
        _isMoving = true;
        _inputPosition = Pointer.current.position.ReadValue();
        OnMove?.Invoke(_inputPosition);
    }

    public void MoveEndInput(InputAction.CallbackContext context)
    {
        _isMoving = false;
        ClearInputs();
        OnStop?.Invoke(_inputPosition);
    }

    private void ClearInputs()
    {
        _inputPosition = Vector2.zero;
    }
        
    private void InitializeInputs()
    {
        _controls = new PlayerMovementInputs();
        _controls.Enable();
        _controls.PlayerMain.MoveStart.performed += MoveStartInput;
        _controls.PlayerMain.MoveEnd.performed += MoveEndInput;
    }
    
    public bool CheckMovementStatus()
    {
        return _isMoving;
    }
}
