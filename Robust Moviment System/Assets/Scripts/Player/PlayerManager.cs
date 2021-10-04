using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    [SerializeField] MovimentManager movimentManager;
    [SerializeField] InputManager inputManager;
    [SerializeField] ActionManager actionManager;
    [SerializeField] CharacterController characterController;
    [SerializeField] AnimationManager animationManager;
    [SerializeField] GameObject meshObject;

    public MovimentManager GetMovimentManager() {
        return movimentManager;
    }

    public InputManager GetInputManager(){
        return inputManager;
    }
    public ActionManager GetActionManager(){
        return actionManager;
    }
    public CharacterController GetCharacterController(){
        return characterController;
    }

    public GameObject GetMeshObject() {
        return meshObject;
    }

    public AnimationManager GetAnimationManager() {
        return animationManager;
    }

}
