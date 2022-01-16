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
            ""name"": ""FightingControls"",
            ""id"": ""e49d4137-a460-4e48-aece-49c8d3e50b02"",
            ""actions"": [
                {
                    ""name"": ""LightAttack"",
                    ""type"": ""Button"",
                    ""id"": ""f40e55ab-956e-44eb-8f13-c4e6a8215300"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HeavyAttack"",
                    ""type"": ""Button"",
                    ""id"": ""c33269fc-3e7f-4710-9da6-83a61571bd64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""ec74f970-06e7-4cfa-8618-c6c722f90937"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""27e9a881-faa4-44f2-a641-25ca7e6948aa"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76cadf40-7661-4943-a2f7-634ffaa4a922"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0d6612d-5992-4db1-a91a-88ee0694098a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FightingControls
        m_FightingControls = asset.FindActionMap("FightingControls", throwIfNotFound: true);
        m_FightingControls_LightAttack = m_FightingControls.FindAction("LightAttack", throwIfNotFound: true);
        m_FightingControls_HeavyAttack = m_FightingControls.FindAction("HeavyAttack", throwIfNotFound: true);
        m_FightingControls_LeftStick = m_FightingControls.FindAction("LeftStick", throwIfNotFound: true);
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

    // FightingControls
    private readonly InputActionMap m_FightingControls;
    private IFightingControlsActions m_FightingControlsActionsCallbackInterface;
    private readonly InputAction m_FightingControls_LightAttack;
    private readonly InputAction m_FightingControls_HeavyAttack;
    private readonly InputAction m_FightingControls_LeftStick;
    public struct FightingControlsActions
    {
        private @Controls m_Wrapper;
        public FightingControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LightAttack => m_Wrapper.m_FightingControls_LightAttack;
        public InputAction @HeavyAttack => m_Wrapper.m_FightingControls_HeavyAttack;
        public InputAction @LeftStick => m_Wrapper.m_FightingControls_LeftStick;
        public InputActionMap Get() { return m_Wrapper.m_FightingControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FightingControlsActions set) { return set.Get(); }
        public void SetCallbacks(IFightingControlsActions instance)
        {
            if (m_Wrapper.m_FightingControlsActionsCallbackInterface != null)
            {
                @LightAttack.started -= m_Wrapper.m_FightingControlsActionsCallbackInterface.OnLightAttack;
                @LightAttack.performed -= m_Wrapper.m_FightingControlsActionsCallbackInterface.OnLightAttack;
                @LightAttack.canceled -= m_Wrapper.m_FightingControlsActionsCallbackInterface.OnLightAttack;
                @HeavyAttack.started -= m_Wrapper.m_FightingControlsActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.performed -= m_Wrapper.m_FightingControlsActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.canceled -= m_Wrapper.m_FightingControlsActionsCallbackInterface.OnHeavyAttack;
                @LeftStick.started -= m_Wrapper.m_FightingControlsActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_FightingControlsActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_FightingControlsActionsCallbackInterface.OnLeftStick;
            }
            m_Wrapper.m_FightingControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LightAttack.started += instance.OnLightAttack;
                @LightAttack.performed += instance.OnLightAttack;
                @LightAttack.canceled += instance.OnLightAttack;
                @HeavyAttack.started += instance.OnHeavyAttack;
                @HeavyAttack.performed += instance.OnHeavyAttack;
                @HeavyAttack.canceled += instance.OnHeavyAttack;
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
            }
        }
    }
    public FightingControlsActions @FightingControls => new FightingControlsActions(this);
    public interface IFightingControlsActions
    {
        void OnLightAttack(InputAction.CallbackContext context);
        void OnHeavyAttack(InputAction.CallbackContext context);
        void OnLeftStick(InputAction.CallbackContext context);
    }
}
