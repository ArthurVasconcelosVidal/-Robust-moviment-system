using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    [SerializeField] MovimentManager movimentManager;
    [SerializeField] InputManager inputManager;
    [SerializeField] ActionManager actionManager;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] GameObject meshObject;
    [SerializeField] Collider playerCollider;

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

    public Collider GetCollider() {
        return playerCollider;
    }

}
