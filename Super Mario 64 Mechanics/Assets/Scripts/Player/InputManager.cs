using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    [SerializeField] PlayerManager playerManager;
    InputControl inputControl;
    Vector2 leftStick;
    bool stickPerforming;
    bool isActionPressed;

    void Awake() {
        inputControl = new InputControl();

        //LeftStick
        inputControl.Moviment.LeftStick.performed += ctx => {
            leftStick = ctx.ReadValue<Vector2>();
            stickPerforming = leftStick.x != 0 || leftStick.y != 0;
        };
        inputControl.Moviment.LeftStick.canceled += ctx => {
            leftStick = ctx.ReadValue<Vector2>();
            stickPerforming = false;
        };

        //ActionButton
        inputControl.Moviment.ActionButton.started += ctx => {
            playerManager.GetMovimentManager().Jump();
            isActionPressed = true;
        };
        inputControl.Moviment.ActionButton.canceled += ctx => {
            isActionPressed = false;
        };
    }

    void OnEnable() {
        inputControl.Moviment.Enable();
    }

    void OnDisable() {
        inputControl.Moviment.Disable();
    }

    public Vector2 LeftStickPerforming() {
        return leftStick;
    }

    public bool IsActionButton() {
        return isActionPressed;
    }
}
