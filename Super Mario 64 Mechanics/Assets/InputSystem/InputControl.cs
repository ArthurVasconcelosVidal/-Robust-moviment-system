// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControl"",
    ""maps"": [
        {
            ""name"": ""Moviment"",
            ""id"": ""4a653342-f6bb-457b-b134-ae31670b5476"",
            ""actions"": [
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""e52d003f-37cf-42e4-bedf-a69994509a07"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""236fd606-9eb0-4821-bfd2-8a029f58ad7d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""b12d2771-f5a9-46ac-a4f8-c9648e8e7f2a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""12e5950b-03fd-468e-84de-34609ff91829"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6df3d35c-b407-461c-af0f-67e5b34ac742"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""84bc4120-b7ae-4992-8218-f06bc9fb03b5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a8027fe1-0e1b-40b3-85e7-0f845302f381"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Moviment
        m_Moviment = asset.FindActionMap("Moviment", throwIfNotFound: true);
        m_Moviment_LeftStick = m_Moviment.FindAction("LeftStick", throwIfNotFound: true);
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

    // Moviment
    private readonly InputActionMap m_Moviment;
    private IMovimentActions m_MovimentActionsCallbackInterface;
    private readonly InputAction m_Moviment_LeftStick;
    public struct MovimentActions
    {
        private @InputControl m_Wrapper;
        public MovimentActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStick => m_Wrapper.m_Moviment_LeftStick;
        public InputActionMap Get() { return m_Wrapper.m_Moviment; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovimentActions set) { return set.Get(); }
        public void SetCallbacks(IMovimentActions instance)
        {
            if (m_Wrapper.m_MovimentActionsCallbackInterface != null)
            {
                @LeftStick.started -= m_Wrapper.m_MovimentActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_MovimentActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_MovimentActionsCallbackInterface.OnLeftStick;
            }
            m_Wrapper.m_MovimentActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
            }
        }
    }
    public MovimentActions @Moviment => new MovimentActions(this);
    public interface IMovimentActions
    {
        void OnLeftStick(InputAction.CallbackContext context);
    }
}
