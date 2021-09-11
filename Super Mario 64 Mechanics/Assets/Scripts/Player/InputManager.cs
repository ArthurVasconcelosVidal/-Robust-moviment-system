using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour{
    InputControl inputControl;
    Vector2 leftStick; 
    bool stickPerforming;

    void Awake(){
        inputControl = new InputControl();

        inputControl.Moviment.LeftStick.performed += ctx => {
            leftStick = ctx.ReadValue<Vector2>();
            stickPerforming = leftStick.x != 0 || leftStick.y != 0;
        };
        inputControl.Moviment.LeftStick.canceled += ctx =>{
            stickPerforming = false;
        };
    }
    
    void OnEnable(){
        inputControl.Moviment.Enable();
    }

    void OnDisable(){
        inputControl.Moviment.Disable();
    }

    public bool LeftStickPerforming(out Vector2 stickValue) {
        stickValue = leftStick;
        return stickPerforming;
    }


}
