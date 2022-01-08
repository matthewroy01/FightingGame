// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""MovementControls"",
            ""id"": ""e49d4137-a460-4e48-aece-49c8d3e50b02"",
            ""actions"": [
                {
                    ""name"": ""MovementHor"",
                    ""type"": ""Value"",
                    ""id"": ""f3ec6a42-8a9e-46d5-ab4a-a6f990e51cd9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MovementVer"",
                    ""type"": ""Value"",
                    ""id"": ""4c6f3460-89e4-424d-9b35-62a81ac6c212"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fc742d04-5cdc-4eec-9338-abdbb7f52b71"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementHor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""101246c4-8f34-40ee-b8bd-b713654c6407"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MovementControls
        m_MovementControls = asset.FindActionMap("MovementControls", throwIfNotFound: true);
        m_MovementControls_MovementHor = m_MovementControls.FindAction("MovementHor", throwIfNotFound: true);
        m_MovementControls_MovementVer = m_MovementControls.FindAction("MovementVer", throwIfNotFound: true);
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

    // MovementControls
    private readonly InputActionMap m_MovementControls;
    private IMovementControlsActions m_MovementControlsActionsCallbackInterface;
    private readonly InputAction m_MovementControls_MovementHor;
    private readonly InputAction m_MovementControls_MovementVer;
    public struct MovementControlsActions
    {
        private @Controls m_Wrapper;
        public MovementControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementHor => m_Wrapper.m_MovementControls_MovementHor;
        public InputAction @MovementVer => m_Wrapper.m_MovementControls_MovementVer;
        public InputActionMap Get() { return m_Wrapper.m_MovementControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMovementControlsActions instance)
        {
            if (m_Wrapper.m_MovementControlsActionsCallbackInterface != null)
            {
                @MovementHor.started -= m_Wrapper.m_MovementControlsActionsCallbackInterface.OnMovementHor;
                @MovementHor.performed -= m_Wrapper.m_MovementControlsActionsCallbackInterface.OnMovementHor;
                @MovementHor.canceled -= m_Wrapper.m_MovementControlsActionsCallbackInterface.OnMovementHor;
                @MovementVer.started -= m_Wrapper.m_MovementControlsActionsCallbackInterface.OnMovementVer;
                @MovementVer.performed -= m_Wrapper.m_MovementControlsActionsCallbackInterface.OnMovementVer;
                @MovementVer.canceled -= m_Wrapper.m_MovementControlsActionsCallbackInterface.OnMovementVer;
            }
            m_Wrapper.m_MovementControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementHor.started += instance.OnMovementHor;
                @MovementHor.performed += instance.OnMovementHor;
                @MovementHor.canceled += instance.OnMovementHor;
                @MovementVer.started += instance.OnMovementVer;
                @MovementVer.performed += instance.OnMovementVer;
                @MovementVer.canceled += instance.OnMovementVer;
            }
        }
    }
    public MovementControlsActions @MovementControls => new MovementControlsActions(this);
    public interface IMovementControlsActions
    {
        void OnMovementHor(InputAction.CallbackContext context);
        void OnMovementVer(InputAction.CallbackContext context);
    }
}
