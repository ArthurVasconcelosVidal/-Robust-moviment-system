using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    [SerializeField] MovimentManager movimentManager;
    [SerializeField] InputManager inputManager;
    [SerializeField] ActionManager actionManager;
    [SerializeField] Rigidbody rigidbody;
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
    public Rigidbody GetRigidbody(){
        return rigidbody;
    }

    public GameObject GetMeshObject() {
        return meshObject;
    }

}
