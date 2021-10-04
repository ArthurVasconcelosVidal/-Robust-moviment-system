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
                },
                {
                    ""name"": ""RightSitck"",
                    ""type"": ""Value"",
                    ""id"": ""251abb99-8f08-4fed-bc78-4e528adff0cc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton"",
                    ""type"": ""Button"",
                    ""id"": ""900d921f-214c-4d82-8097-243964208f34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WestButton"",
                    ""type"": ""Button"",
                    ""id"": ""202adf05-83e6-47ca-b104-5a33a5ee3c1b"",
                    ""expectedControlType"": ""Button"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""d4583d4c-e26e-4684-ac8e-a2dd37bdfb4d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f265cc26-3815-4a9f-9ec9-8db67ebfebc2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""939afb94-7686-4136-8a9a-dc0ed0632d84"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0229de78-399f-4c6f-84b7-f1376607592f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c466a25-f111-4d25-bc9a-f5fd5b944bf1"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e616e5f4-f079-47fb-bdbb-317075a06e5b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc44bec6-0572-46e2-bda0-00bdcfda7e45"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSitck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Setass"",
                    ""id"": ""7b338803-e054-45c0-b781-3da4d4f133ca"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSitck"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""aff70253-d416-448c-8480-f3a37e2edb16"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSitck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""17de707a-acf3-4680-9482-a6df36ad0b3f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSitck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""22f4def0-f8c2-4d0c-ac1b-c9ab2542eca6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSitck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bfc7be4d-8607-4360-8165-c47219c7ad7d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSitck"",
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
        m_Moviment_RightSitck = m_Moviment.FindAction("RightSitck", throwIfNotFound: true);
        m_Moviment_ActionButton = m_Moviment.FindAction("ActionButton", throwIfNotFound: true);
        m_Moviment_WestButton = m_Moviment.FindAction("WestButton", throwIfNotFound: true);
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
    private readonly InputAction m_Moviment_RightSitck;
    private readonly InputAction m_Moviment_ActionButton;
    private readonly InputAction m_Moviment_WestButton;
    public struct MovimentActions
    {
        private @InputControl m_Wrapper;
        public MovimentActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStick => m_Wrapper.m_Moviment_LeftStick;
        public InputAction @RightSitck => m_Wrapper.m_Moviment_RightSitck;
        public InputAction @ActionButton => m_Wrapper.m_Moviment_ActionButton;
        public InputAction @WestButton => m_Wrapper.m_Moviment_WestButton;
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
                @RightSitck.started -= m_Wrapper.m_MovimentActionsCallbackInterface.OnRightSitck;
                @RightSitck.performed -= m_Wrapper.m_MovimentActionsCallbackInterface.OnRightSitck;
                @RightSitck.canceled -= m_Wrapper.m_MovimentActionsCallbackInterface.OnRightSitck;
                @ActionButton.started -= m_Wrapper.m_MovimentActionsCallbackInterface.OnActionButton;
                @ActionButton.performed -= m_Wrapper.m_MovimentActionsCallbackInterface.OnActionButton;
                @ActionButton.canceled -= m_Wrapper.m_MovimentActionsCallbackInterface.OnActionButton;
                @WestButton.started -= m_Wrapper.m_MovimentActionsCallbackInterface.OnWestButton;
                @WestButton.performed -= m_Wrapper.m_MovimentActionsCallbackInterface.OnWestButton;
                @WestButton.canceled -= m_Wrapper.m_MovimentActionsCallbackInterface.OnWestButton;
            }
            m_Wrapper.m_MovimentActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @RightSitck.started += instance.OnRightSitck;
                @RightSitck.performed += instance.OnRightSitck;
                @RightSitck.canceled += instance.OnRightSitck;
                @ActionButton.started += instance.OnActionButton;
                @ActionButton.performed += instance.OnActionButton;
                @ActionButton.canceled += instance.OnActionButton;
                @WestButton.started += instance.OnWestButton;
                @WestButton.performed += instance.OnWestButton;
                @WestButton.canceled += instance.OnWestButton;
            }
        }
    }
    public MovimentActions @Moviment => new MovimentActions(this);
    public interface IMovimentActions
    {
        void OnLeftStick(InputAction.CallbackContext context);
        void OnRightSitck(InputAction.CallbackContext context);
        void OnActionButton(InputAction.CallbackContext context);
        void OnWestButton(InputAction.CallbackContext context);
    }
}
