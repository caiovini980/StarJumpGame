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
                    ""name"": ""MoveStart"",
                    ""type"": ""Button"",
                    ""id"": ""2b47749f-f4b0-448a-bd58-e9f151c5681f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveEnd"",
                    ""type"": ""Button"",
                    ""id"": ""98ef1cbc-6740-45fa-975b-96f880759896"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""BreakPlatform"",
                    ""type"": ""Button"",
                    ""id"": ""8cc3c483-3eb7-41ec-9979-2929d32911e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""27abf894-6c35-4c6d-bbf5-c709d8f9539b"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f997509c-d92d-477b-83cf-11fd093c0412"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15781f32-b062-4a79-937d-82deadeb9a99"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28d7413b-ae47-4a80-b6e9-bf5ccf0df0cc"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f79baeb1-373e-4483-ae6a-3dfa0a39560b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BreakPlatform"",
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
        m_PlayerMain_MoveStart = m_PlayerMain.FindAction("MoveStart", throwIfNotFound: true);
        m_PlayerMain_MoveEnd = m_PlayerMain.FindAction("MoveEnd", throwIfNotFound: true);
        m_PlayerMain_BreakPlatform = m_PlayerMain.FindAction("BreakPlatform", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerMain_MoveStart;
    private readonly InputAction m_PlayerMain_MoveEnd;
    private readonly InputAction m_PlayerMain_BreakPlatform;
    public struct PlayerMainActions
    {
        private @PlayerMovementInputs m_Wrapper;
        public PlayerMainActions(@PlayerMovementInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveStart => m_Wrapper.m_PlayerMain_MoveStart;
        public InputAction @MoveEnd => m_Wrapper.m_PlayerMain_MoveEnd;
        public InputAction @BreakPlatform => m_Wrapper.m_PlayerMain_BreakPlatform;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMainActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMainActions instance)
        {
            if (m_Wrapper.m_PlayerMainActionsCallbackInterface != null)
            {
                @MoveStart.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMoveStart;
                @MoveStart.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMoveStart;
                @MoveStart.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMoveStart;
                @MoveEnd.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMoveEnd;
                @MoveEnd.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMoveEnd;
                @MoveEnd.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnMoveEnd;
                @BreakPlatform.started -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnBreakPlatform;
                @BreakPlatform.performed -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnBreakPlatform;
                @BreakPlatform.canceled -= m_Wrapper.m_PlayerMainActionsCallbackInterface.OnBreakPlatform;
            }
            m_Wrapper.m_PlayerMainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveStart.started += instance.OnMoveStart;
                @MoveStart.performed += instance.OnMoveStart;
                @MoveStart.canceled += instance.OnMoveStart;
                @MoveEnd.started += instance.OnMoveEnd;
                @MoveEnd.performed += instance.OnMoveEnd;
                @MoveEnd.canceled += instance.OnMoveEnd;
                @BreakPlatform.started += instance.OnBreakPlatform;
                @BreakPlatform.performed += instance.OnBreakPlatform;
                @BreakPlatform.canceled += instance.OnBreakPlatform;
            }
        }
    }
    public PlayerMainActions @PlayerMain => new PlayerMainActions(this);
    public interface IPlayerMainActions
    {
        void OnMoveStart(InputAction.CallbackContext context);
        void OnMoveEnd(InputAction.CallbackContext context);
        void OnBreakPlatform(InputAction.CallbackContext context);
    }
}
