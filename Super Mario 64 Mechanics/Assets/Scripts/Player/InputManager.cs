using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour{
    [SerializeField] PlayerManager playerManager;
    InputControl inputControl;
    Vector2 leftStick; 
    bool stickPerforming;

    void Awake(){
        inputControl = new InputControl();
        
        //LeftStick
        inputControl.Moviment.LeftStick.performed += ctx => {
            leftStick = ctx.ReadValue<Vector2>();
            stickPerforming = leftStick.x != 0 || leftStick.y != 0;
        };
        inputControl.Moviment.LeftStick.canceled += ctx =>{
            leftStick = ctx.ReadValue<Vector2>();
            stickPerforming = false;
        };

        //ActionButton
        inputControl.Moviment.ActionButton.performed += ctx =>{
            playerManager.GetMovimentManager().Jump(); 
        };
    }
    
    void OnEnable(){
        inputControl.Moviment.Enable();
    }

    void OnDisable(){
        inputControl.Moviment.Disable();
    }

    public Vector2 LeftStickPerforming() {
        return leftStick;
    }


}
