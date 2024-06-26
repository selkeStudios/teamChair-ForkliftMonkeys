//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""8a17d04a-bd6b-4d77-bdf9-561f5c1f5d6a"",
            ""actions"": [
                {
                    ""name"": ""Wheel"",
                    ""type"": ""Value"",
                    ""id"": ""6153af8e-d54c-4e16-84de-3dd77d30d1b1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""9c7de68b-2266-4c75-bc24-2ba0ce8a4605"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reverse"",
                    ""type"": ""Button"",
                    ""id"": ""5e80c13a-602c-4ca3-a1d5-069ac6387161"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Use Item"",
                    ""type"": ""Button"",
                    ""id"": ""f24bef55-7945-404e-86b1-2c0ca636094a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Horn"",
                    ""type"": ""Button"",
                    ""id"": ""3091f3c0-55e4-4b1a-b551-8c4fc25f3cd5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6a2e2259-3cfa-458e-8dd9-018506ca6a47"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0956fd1-bacf-4245-90ed-8ebbb6c5e1f9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a8e4e41-161c-4174-979b-9859252f79f8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a70b8ac3-11a5-444e-bf59-dc53705184f7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9555462-1f0d-4c65-8d1f-fa5ad7719dd9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""400aef12-15be-4646-b8ad-998b0f8e5762"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c631cd6-29a6-48a3-8363-a784904f9676"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5010cbd2-39bf-4cf6-a8a2-ce4c52071606"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e03ef62-c048-4727-bcc6-f2e6928cca94"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c3ba79e-d97a-477a-a321-54ff045df1a9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Move with Wheel"",
                    ""id"": ""e739c40d-ba16-4553-9567-30492f523da3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wheel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a0b2d53c-f986-4a02-8f93-046a203c3c6f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d22bdf07-e9f4-4768-bad7-417950b8493c"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Move with Keyboard"",
                    ""id"": ""847f9538-ca7c-404b-8263-328d98d3c7b2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wheel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""11f0ce36-7efc-49c9-8417-21fc60a29b4b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""30cc4d41-1e6b-41b6-9f24-32a440eaadb6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Wheel = m_Player1.FindAction("Wheel", throwIfNotFound: true);
        m_Player1_Accelerate = m_Player1.FindAction("Accelerate", throwIfNotFound: true);
        m_Player1_Reverse = m_Player1.FindAction("Reverse", throwIfNotFound: true);
        m_Player1_UseItem = m_Player1.FindAction("Use Item", throwIfNotFound: true);
        m_Player1_Horn = m_Player1.FindAction("Horn", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Wheel;
    private readonly InputAction m_Player1_Accelerate;
    private readonly InputAction m_Player1_Reverse;
    private readonly InputAction m_Player1_UseItem;
    private readonly InputAction m_Player1_Horn;
    public struct Player1Actions
    {
        private @InputActions m_Wrapper;
        public Player1Actions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Wheel => m_Wrapper.m_Player1_Wheel;
        public InputAction @Accelerate => m_Wrapper.m_Player1_Accelerate;
        public InputAction @Reverse => m_Wrapper.m_Player1_Reverse;
        public InputAction @UseItem => m_Wrapper.m_Player1_UseItem;
        public InputAction @Horn => m_Wrapper.m_Player1_Horn;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Wheel.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWheel;
                @Wheel.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWheel;
                @Wheel.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWheel;
                @Accelerate.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAccelerate;
                @Reverse.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnReverse;
                @Reverse.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnReverse;
                @Reverse.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnReverse;
                @UseItem.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUseItem;
                @UseItem.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUseItem;
                @UseItem.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUseItem;
                @Horn.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnHorn;
                @Horn.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnHorn;
                @Horn.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnHorn;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Wheel.started += instance.OnWheel;
                @Wheel.performed += instance.OnWheel;
                @Wheel.canceled += instance.OnWheel;
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Reverse.started += instance.OnReverse;
                @Reverse.performed += instance.OnReverse;
                @Reverse.canceled += instance.OnReverse;
                @UseItem.started += instance.OnUseItem;
                @UseItem.performed += instance.OnUseItem;
                @UseItem.canceled += instance.OnUseItem;
                @Horn.started += instance.OnHorn;
                @Horn.performed += instance.OnHorn;
                @Horn.canceled += instance.OnHorn;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);
    public interface IPlayer1Actions
    {
        void OnWheel(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
        void OnReverse(InputAction.CallbackContext context);
        void OnUseItem(InputAction.CallbackContext context);
        void OnHorn(InputAction.CallbackContext context);
    }
}
