using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    [SerializeField] PlayerManager playerManager;
    InputControl inputControl;
    [SerializeField] Vector2 leftStick; //Serialized for Debug
    [SerializeField] Vector2 rightStick; //Serialized for Debug
    [SerializeField] bool stickPerforming; //Serialized for Debug
    bool isActionPressed;
    bool isWestPressed;

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
        inputControl.Moviment.LeftStick.started += ctx => {
            playerManager.GetMovimentManager().StartMovimentProgression();
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

        //WestButton
        inputControl.Moviment.WestButton.started += ctx =>{
            isWestPressed = true;
        };
        inputControl.Moviment.WestButton.canceled += ctx => {
            isWestPressed = false;
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

    public bool IsWestButton() {
        return isWestPressed;
    }
}
