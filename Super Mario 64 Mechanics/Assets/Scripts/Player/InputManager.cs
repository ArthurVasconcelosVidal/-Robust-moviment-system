using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    [SerializeField] PlayerManager playerManager;
    InputControl inputControl;
    [SerializeField] Vector2 leftStick; //Serialized for Debug
    [SerializeField] Vector2 rightStick; //Serialized for Debug
    bool isActionPressed;

    void Awake() {
        inputControl = new InputControl();

        //LeftStick
        inputControl.Moviment.LeftStick.performed += ctx => {
            leftStick = ctx.ReadValue<Vector2>();
        };
        inputControl.Moviment.LeftStick.canceled += ctx => {
            leftStick = ctx.ReadValue<Vector2>();
        };

        //RightStick
        inputControl.Moviment.RightSitck.performed += ctx => {
            rightStick = ctx.ReadValue<Vector2>();
        };
        inputControl.Moviment.RightSitck.canceled += ctx => {
            rightStick = ctx.ReadValue<Vector2>();
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

    public Vector2 RightStickPerforming() {
        return rightStick;
    }

    public bool IsActionButton() {
        return isActionPressed;
    }
}
