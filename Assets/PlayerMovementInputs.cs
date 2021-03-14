// GENERATED AUTOMATICALLY FROM 'Assets/PlayerMovementInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerMovementInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMovementInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMovementInputs"",
    ""maps"": [
        {
            ""name"": ""PlayerMain"",
            ""id"": ""ba7e1f53-168b-409b-be77-7ac80b129e7d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f68eb637-55d2-4b7b-af9f-56707cfe719a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dba2bde7-b0cd-49f7-b0a8-d1d7fdad9c37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""19fa372d-d270-4402-b16a-de5ce03f2ea7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""087663b3-368d-4bce-966d-67db245c6eb3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5d02a951-5f27-4ad6-b5de-0cc4bfe81363"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c8226f57-8283-49b0-89dd-663162fb6672"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""10d8a950-52fd-40f0-aa05-394ef581b79b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f5ad2a54-e495-4795-a033-cf9caecf5280"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Sideways"",
                    ""id"": ""0975102e-d58a-4dec-959c-77418afa6cba"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""49b11683-82ba-42d0-9fcd-c730e53a5fcd"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""aa4e5fb2-b349-45be-9c97-400122d6b63f"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""TouchControls"",
            ""id"": ""d7fe9d10-d93e-4035-b16a-885f4fc8489f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f43d5d96-23f9-446a-9fa2-2a2f4ba3e4cc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""20f287a9-a35e-438f-bd89-d0decd898287"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMain
        m_PlayerMain = asset.FindActionMap("PlayerMain", throwIfNotFound: true);
        m_PlayerMain_Move = m_PlayerMain.FindAction("Move", throwIfNotFound: true);
        m_PlayerMain_Movement = m_PlayerMain.FindAction("Movement", throwIfNotFound: true);
        // TouchControls
        m_TouchControls = asset.FindActionMap("TouchControls", throwIfNotFound: true);
        m_TouchControls_Move = m_TouchControls.FindAction("Move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerMain
    private readonly InputActionMap m_PlayerMain;
    private IPlayerMainActions m_PlayerMainActionsCallbackInterface;
    private readonly InputAction m_PlayerMain_Move;
    private readonly InputAction m_PlayerMain_Movement;
    public struct PlayerMainActions
    {
        private @PlayerMovementInputs m_Wrapper;
        public PlayerMainActions(@PlayerMovementInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMain_Move;
        public InputAction @Movement => m_Wrapper.m_PlayerMain_Movement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMainActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMainActions instance)
        {
            if (m_Wrapper.m_PlayerMainActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMove;
                @Movement.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayerMainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public PlayerMainActions @PlayerMain => new PlayerMainActions(this);

    // TouchControls
    private readonly InputActionMap m_TouchControls;
    private ITouchControlsActions m_TouchControlsActionsCallbackInterface;
    private readonly InputAction m_TouchControls_Move;
    public struct TouchControlsActions
    {
        private @PlayerMovementInputs m_Wrapper;
        public TouchControlsActions(@PlayerMovementInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TouchControls_Move;
        public InputActionMap Get() { return m_Wrapper.m_TouchControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchControlsActions set) { return set.Get(); }
        public void SetCallbacks(ITouchControlsActions instance)
        {
            if (m_Wrapper.m_TouchControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TouchControlsActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_TouchControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public TouchControlsActions @TouchControls => new TouchControlsActions(this);
    public interface IPlayerMainActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface ITouchControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
